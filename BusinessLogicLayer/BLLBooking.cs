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
   public class BLLBooking
    {
       public int Booking(string RName, string TName, DateTime BTime, string CNumber, string Address, string Package, DateTime ETime,int Rate,string SDate)
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = "insert into tblBooking(RName,TName,BTime,CNumber,Address,Package,ETime,Rate,SDate)values(@RName,@TName,@BTime,@CNumber,@Address,@Package,@ETime,@Rate,@SDate)";
           SqlCommand cmd = new SqlCommand(sqlQuery, conn);
           cmd.Parameters.AddWithValue("@RName", RName);
           cmd.Parameters.AddWithValue("@TName", TName);
           cmd.Parameters.AddWithValue("@BTime", BTime);          
           cmd.Parameters.AddWithValue("@CNumber", CNumber);
           cmd.Parameters.AddWithValue("@Address", Address);
           cmd.Parameters.AddWithValue("@Package", Package);
           cmd.Parameters.AddWithValue("@ETime", ETime);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@SDate", SDate);
            
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
      public bool IsValidBooking(DateTime BTime)
      {
           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = "select * from tblBooking where BTime=@BTime  ";
           SqlCommand cmd = new SqlCommand(sqlQuery, conn);         
           cmd.Parameters.AddWithValue("@BTime", BTime);
           SqlDataReader sqlread = null;
           try
           {
               conn.Open();
               sqlread = cmd.ExecuteReader();
               if (sqlread.Read())
                   return true;
               else
                   return false;
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
          public DataTable  View()
          {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select * from tblBooking order by BTime DESC";
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];


          }
        public DataTable DescendingVsch()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select BookID,TName,RName,CONVERT(VARCHAR(5),BTime,108)AS BTime,CNumber,Address,Package,ETime,Rate from tblBooking order by BTime DESC";
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];


        }
        public DataTable DescendingView()
          {
              SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
              string SqlQuery = "select * from tblBooking order by BTime DESC";
              SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
              SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
              DataSet ds = new DataSet();
              da.Fill(ds, "user");
              return ds.Tables["user"];


          }
          public DataTable GetScheduleByDate(DateTime BTime)
          {
              SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
              string SqlQuery = "select * from tblBooking where CAST(BTime AS DATE) = CAST(GETDATE() AS DATE) ORDER by BTime DESC";
              SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
              SqlCmd.Parameters.AddWithValue("@BTime", BTime+ "%");
              SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
              DataSet ds = new DataSet();
              da.Fill(ds, "user");
              return ds.Tables["user"];
          }
        public DataTable GetScheduleBytom(DateTime Btom)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select * from tblBooking where CAST(BTime AS DATE) = CAST((GETDATE()+1) AS DATE) ORDER by BTime DESC";
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlCmd.Parameters.AddWithValue("@BTime", Btom + "%");
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];
        }



        public DataTable GetScheduleByid(String BookID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select * from tblBooking where BookID like @BookID";
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlCmd.Parameters.AddWithValue("@BookID", BookID + "%");
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];
        }
        public DataTable GetScheduleByName(String RName)
          {
              SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
              string SqlQuery = "select * from tblBooking where RName like @RName ";
              SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlCmd.Parameters.AddWithValue("@RName", RName + "%");
              SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
              DataSet ds = new DataSet();
              da.Fill(ds, "user");
              return ds.Tables["user"];
          }
        public DataTable searchbydate(string SDate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string SqlQuery = "select * from tblBooking where SDate like @SDate ORDER by BTime DESC";
            /*where CAST(BTime AS DATE) = CAST(GETDATE() AS DATE)*/
            SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
            SqlCmd.Parameters.AddWithValue("@SDate", SDate + "%");
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "user");
            return ds.Tables["user"];
        }

        public int CancelBooking(int BookID, string RName)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sqlQuery = "delete from tblBooking where BookID = @BookID and RName = @RName ";
           // string sqlQuery = "delete from tblBooking where BooKID = @BooKID AND RName = @RName";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@BookID", BookID);
            cmd.Parameters.AddWithValue("@RName", RName);

            //string sqlQuery = " delete from tblBooking where BookID=@BookID and RName=@RName";
            //SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            //cmd.Parameters.AddWithValue("@BookID", BookID);
            //cmd.Parameters.AddWithValue("@RName", RName);
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
        public int UpdateBooking(int BookID, string RName, string TName, DateTime BTime, string CNumber, string Address, string Package, DateTime ETime)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sqlQuery = " update tblBooking set RName=@RName,TName=@TName,BTime=@BTime,CNumber=@CNumber,Address=@Address,Package=@Package,ETime=@ETime where BookID=@BookID ";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@BookID", BookID);
            cmd.Parameters.AddWithValue("@RName", RName);
            cmd.Parameters.AddWithValue("@TName", TName);
            cmd.Parameters.AddWithValue("@BTime", BTime);
            cmd.Parameters.AddWithValue("@CNumber", CNumber);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Package", Package);
            cmd.Parameters.AddWithValue("@ETime", ETime);
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

         public bool IsTime(DateTime BTime)
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
             string sqlQuery = "select EXTRACT(HOUR FROM BTime) As BTime from tblBooking where  BTime=@BTime  ";
             SqlCommand cmd = new SqlCommand(sqlQuery, conn);
             cmd.Parameters.AddWithValue("@BTime", BTime);
             SqlDataReader sqlread = null;
             try
             {
                 conn.Open();
                 sqlread = cmd.ExecuteReader();
                 if (sqlread.Read())
                     return true;
                 else
                     return false;
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
    
        }

      }
     
    








    
      

     

