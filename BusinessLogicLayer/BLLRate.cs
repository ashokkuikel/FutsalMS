using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BusinessLogicLayer
{
  public  class BLLRate
    {

        public int AddPackage(string Package, double Rate)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sqlQuery = "insert into tblRate(Package,Rate)values(@Package,@Rate)";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@package", Package);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();//used for CUD
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable PackageView()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select * from tblRate";
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];
        }
        public int PackageDelete(string Package)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sqlQuery = " delete from tblPackage where Package=@Package";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@TName", Package);       
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();//used for CUD
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public int PackageUpdate(string Package, double Rate)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sqlQuery = " update tblRate SET  Package=@Package  Rate=@Rate ";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@Package", Package);
            cmd.Parameters.AddWithValue("@Rate", Rate);

            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();//used for CUD
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


        }








        public int PackageUpdate(BLLRate package, double Rate)
        {
            throw new NotImplementedException();
        }
    }
}
