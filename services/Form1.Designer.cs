namespace services
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeSvc = new System.Windows.Forms.TreeView();
            this.contextMenuStripRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSvcCategoryRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripChild = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddNewSvc = new System.Windows.Forms.ToolStripMenuItem();
            this.editSvc = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSvc = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRoot.SuspendLayout();
            this.contextMenuStripChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeSvc
            // 
            this.treeSvc.AllowDrop = true;
            this.treeSvc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSvc.Location = new System.Drawing.Point(12, 21);
            this.treeSvc.Name = "treeSvc";
            this.treeSvc.Size = new System.Drawing.Size(227, 220);
            this.treeSvc.TabIndex = 0;
            this.treeSvc.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeSvc_AfterLabelEdit);
            this.treeSvc.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeSvc_BeforeExpand);
            this.treeSvc.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeSvc_ItemDrag);
            this.treeSvc.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeSvc_DragDrop);
            this.treeSvc.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeSvc_DragEnter);
            this.treeSvc.DragOver += new System.Windows.Forms.DragEventHandler(this.treeSvc_DragOver);
            this.treeSvc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeSvc_MouseUp);
            // 
            // contextMenuStripRoot
            // 
            this.contextMenuStripRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSvcCategoryRoot});
            this.contextMenuStripRoot.Name = "contextMenuStripRoot";
            this.contextMenuStripRoot.Size = new System.Drawing.Size(261, 26);
            // 
            // addNewSvcCategoryRoot
            // 
            this.addNewSvcCategoryRoot.Name = "addNewSvcCategoryRoot";
            this.addNewSvcCategoryRoot.Size = new System.Drawing.Size(260, 22);
            this.addNewSvcCategoryRoot.Text = "Добавить новую категорию услуг";
            this.addNewSvcCategoryRoot.Click += new System.EventHandler(this.addNewSvcCategoryRoot_Click);
            // 
            // contextMenuStripChild
            // 
            this.contextMenuStripChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewSvc,
            this.editSvc,
            this.deleteSvc});
            this.contextMenuStripChild.Name = "contextMenuChild";
            this.contextMenuStripChild.Size = new System.Drawing.Size(205, 70);
            // 
            // AddNewSvc
            // 
            this.AddNewSvc.Name = "AddNewSvc";
            this.AddNewSvc.Size = new System.Drawing.Size(204, 22);
            this.AddNewSvc.Text = "Добавить новую услугу";
            this.AddNewSvc.Click += new System.EventHandler(this.AddNewSvc_Click);
            // 
            // editSvc
            // 
            this.editSvc.Name = "editSvc";
            this.editSvc.Size = new System.Drawing.Size(204, 22);
            this.editSvc.Text = "Переименовать";
            this.editSvc.Click += new System.EventHandler(this.editSvc_Click);
            // 
            // deleteSvc
            // 
            this.deleteSvc.Name = "deleteSvc";
            this.deleteSvc.Size = new System.Drawing.Size(204, 22);
            this.deleteSvc.Text = "Удалить";
            this.deleteSvc.Click += new System.EventHandler(this.deleteSvc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 269);
            this.Controls.Add(this.treeSvc);
            this.Name = "Form1";
            this.Text = "Услуги";
            this.contextMenuStripRoot.ResumeLayout(false);
            this.contextMenuStripChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeSvc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRoot;
        private System.Windows.Forms.ToolStripMenuItem addNewSvcCategoryRoot;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChild;
        private System.Windows.Forms.ToolStripMenuItem AddNewSvc;
        private System.Windows.Forms.ToolStripMenuItem editSvc;
        private System.Windows.Forms.ToolStripMenuItem deleteSvc;
    }
}

