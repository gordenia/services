using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace services
{
    public partial class Form1 : Form
    {
        MenuItem getMenuItem;

        private enum MenuItem
        {
            addSvc,
            editSvc
        }

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            BuildTreeSvc(null, treeSvc.Nodes);
            AssignContextMenuToRoot();
        }

        private void BuildTreeSvc(int? parentId, TreeNodeCollection parentNode)
        {
            DBManipulation dbManipulation = new DBManipulation();
            TreeNode childNode = new TreeNode();
            DbDataReader dataSvcChild;

            dataSvcChild = (parentId == null) ? dbManipulation.getSvcParent() : dbManipulation.getSvcChild(parentId.Value);

            while (dataSvcChild.Read())
            {
                string svc_id = dataSvcChild.GetString(0);
                string name = dataSvcChild.GetString(1);
                int count_child = dataSvcChild.GetInt32(2);

                childNode = (parentNode == null) ? treeSvc.Nodes.Add(svc_id, name) : childNode = parentNode.Add(svc_id, name);
                childNode.Tag = svc_id;

                if (count_child > 0)
                    childNode.Nodes.Add("_" + svc_id, "fict");

                childNode.ContextMenuStrip = contextMenuStripChild;
            }

            dataSvcChild.Close();
        }

        private void AssignContextMenuToRoot()
        {
            treeSvc.ContextMenuStrip = contextMenuStripRoot;
        }

        private void AssignContextMenuToChild(TreeNode nodeName)
        {
            foreach (TreeNode childNode in nodeName.Nodes)
            {
                childNode.ContextMenuStrip = contextMenuStripChild;
                AssignContextMenuToChild(childNode);
            }
        }

        private void treeSvc_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (!treeSvc.LabelEdit)
            {
                e.Node.Nodes.Clear();
                BuildTreeSvc(Convert.ToInt32(e.Node.Tag), e.Node.Nodes);
            }
        }

        private void addNewSvcCategoryRoot_Click(object sender, EventArgs e)
        {
            AddNewNode(sender, e, treeSvc.Nodes);
        }

        private void AddNewSvc_Click(object sender, EventArgs e)
        {
            treeSvc.SelectedNode.Expand();
            AddNewNode(sender, e, treeSvc.SelectedNode.Nodes);
        }

        private void AddNewNode(object sender, EventArgs e, TreeNodeCollection treeNodeCollection)
        {
            TreeNode newNode = new TreeNode(String.Format(""));
            newNode.ContextMenuStrip = contextMenuStripChild;

            getMenuItem = MenuItem.addSvc;
            treeSvc.LabelEdit = true;
            treeSvc.SelectedNode = newNode;

            treeNodeCollection.Add(newNode);
            newNode.BeginEdit();
        }

        private void treeSvc_AfterLabelEdit(object sender,
         System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if ((e.Label != null) && !(e.Label == ""))
            {
                treeSvc.LabelEdit = false;
                e.Node.EndEdit(true);

                DBManipulation dbManipulation = new DBManipulation();

                if (getMenuItem == MenuItem.addSvc)
                {
                    e.Node.Tag = (e.Node.Parent == null) ? dbManipulation.insertTreeSvc(null, e.Label) : dbManipulation.insertTreeSvc((Convert.ToInt32(e.Node.Parent.Tag)), e.Label);
                }
                else if (getMenuItem == MenuItem.editSvc)
                {
                    dbManipulation.updateSvc(Convert.ToInt32(e.Node.Tag), e.Label);
                }
            }
            else if (getMenuItem == MenuItem.addSvc)
            {
                e.Node.Remove();
            }
            else if (getMenuItem == MenuItem.editSvc)
            {
                e.CancelEdit = true;
            }
        }

        private void treeSvc_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode node = treeSvc.GetNodeAt(p);
                if (node != null)
                {
                    treeSvc.SelectedNode = node;
                }
            }
        }

        private void editSvc_Click(object sender, EventArgs e)
        {
            getMenuItem = MenuItem.editSvc;
            treeSvc.LabelEdit = true;
            treeSvc.SelectedNode.BeginEdit();
        }

        private void deleteSvc_Click(object sender, EventArgs e)
        {
            DBManipulation dbManipulation = new DBManipulation();
            dbManipulation.deleteSvc(Convert.ToInt32(treeSvc.SelectedNode.Tag));
            treeSvc.SelectedNode.Remove();
        }

        private void treeSvc_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeSvc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeSvc_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeSvc.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeSvc.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                draggedNode.Remove();

                DBManipulation dbManipulation = new DBManipulation();

                if (targetNode == null)
                {
                    treeSvc.Nodes.Add(draggedNode);
                    dbManipulation.updateTreeSvc(null, Convert.ToInt32(draggedNode.Tag));
                }
                else
                {
                    targetNode.Nodes.Add(draggedNode);
                    dbManipulation.updateTreeSvc(Convert.ToInt32(targetNode.Tag), Convert.ToInt32(draggedNode.Tag));
                }

                targetNode.Expand();
            }
        }

        private void treeSvc_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeSvc.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = treeSvc.GetNodeAt(targetPoint);
            treeSvc.SelectedNode = targetNode;
        }

        private bool ContainsNode(TreeNode dragged, TreeNode target)
        {
            if ((target==null) || (target.Parent == null))
                return false;
            return (target.Parent.Equals(dragged)) ? true : ContainsNode(dragged, target.Parent);
        }

    }
}
