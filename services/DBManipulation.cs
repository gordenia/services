using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace services
{
    class DBManipulation
    {
        public DBManipulation()
        {
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
            }
            catch(Exception e)
            {
                ExceptionHandler.SqlExceptionProcess(e);
                Environment.Exit(1);
            }
        }

        ~DBManipulation()
        {
            conn.Close();
        }

        public DbDataReader getSvcParent()
        {
            string query = "SELECT" +
                             " tsr.svc_id," +
                             " tsr.name," +
                             "(SELECT COUNT(*) FROM t_svc_ref tsr1 WHERE tsr1.parent_id = tsr.svc_id) AS count_child " +
                           "FROM t_svc_ref tsr WHERE tsr.parent_id is NULL";
            MySqlCommand getNodes = new MySqlCommand(query, conn);
            try
            {
                return getNodes.ExecuteReader();
            }
            catch(Exception e)
            {
                ExceptionHandler.SqlExceptionProcess(e);
                Environment.Exit(1);
                return null;
            }
        }

        public DbDataReader getSvcChild(int parentId)
        {
            string query = "SELECT tsr.svc_id, tsr.name, (SELECT COUNT(*) FROM t_svc_ref tsr1 WHERE tsr1.parent_id = tsr.svc_id) AS count_child  FROM t_svc_ref tsr WHERE tsr.parent_id = @parentId";
            MySqlCommand getChild = new MySqlCommand(query, conn);
            getChild.Parameters.AddWithValue("@parentId", parentId);
            
            return getChild.ExecuteReader();
        }

        public long insertTreeSvc(int? parentId, string name)
        {
            string query = "INSERT INTO t_svc_ref(parent_id, name) VALUES(@parentId, @name)";
            MySqlCommand newSvc = new MySqlCommand(query, conn);
            newSvc.Parameters.AddWithValue("@parentId", parentId);
            newSvc.Parameters.AddWithValue("@name", name);
            newSvc.ExecuteNonQuery();
            return newSvc.LastInsertedId;
        }

        public void updateSvc(int svcId, string name)
        {
            string query = "UPDATE t_svc_ref1 SET name =  @name WHERE svc_id = @svcId";
            MySqlCommand newSvc = new MySqlCommand(query, conn);
            newSvc.Parameters.AddWithValue("@svcId", svcId);
            newSvc.Parameters.AddWithValue("@name", name);
            newSvc.ExecuteNonQuery();
        }

        public void updateTreeSvc(int? targetNode, int draggedNode)
        {
            string query = "UPDATE t_svc_ref SET parent_id = @targetSvcId WHERE svc_id = @draggedSvcId";
            MySqlCommand newSvc = new MySqlCommand(query, conn);
            newSvc.Parameters.AddWithValue("@draggedSvcId", draggedNode);
            newSvc.Parameters.AddWithValue("@targetSvcId", targetNode);
            newSvc.ExecuteNonQuery();
        }

        public void deleteSvc(int svcId)
        {
            DbDataReader getChild = getSvcChild(svcId);

            string query = (getChild.HasRows) ?
                "DELETE FROM t_svc_ref WHERE parent_id = @svcId OR svc_id = @svcId" :
                "DELETE FROM t_svc_ref WHERE svc_id = @svcId";

            getChild.Close();

            MySqlCommand newSvc = new MySqlCommand(query, conn);
            newSvc.Parameters.AddWithValue("@svcId", svcId);
            newSvc.ExecuteNonQuery();
        }

        private MySqlConnection conn;
    }
}
