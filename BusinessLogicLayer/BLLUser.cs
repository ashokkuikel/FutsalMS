using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Specialized;

namespace BusinessLogicLayer
{
   public class BLLUser
    {
       public int CreateUser(string UserName, string Password)
       {

           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = "insert into tblUser(UserName,Password)values(@UserName,@Password)";

           SqlCommand cmd = new SqlCommand(sqlQuery, conn);
           cmd.Parameters.AddWithValue("@UserName", UserName);
           cmd.Parameters.AddWithValue("@Password", Password);
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

       public bool IsValidUser(string UserName, string Password)
       {

           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = "select * from tblUser where  UserName=@UserName and Password=@Password ";
           SqlCommand cmd = new SqlCommand(sqlQuery, conn);
           //cmd.Parameters.AddWithValue("@UserID", UserID);
           cmd.Parameters.AddWithValue("@UserName", UserName);
           cmd.Parameters.AddWithValue("@Password", Password);
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
       public DataTable View()
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string SqlQuery = "select * from tblUser";
           SqlCommand SqlCmd = new SqlCommand(SqlQuery, conn);
           SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
           DataSet ds = new DataSet();
           da.Fill(ds, "user");
           return ds.Tables["user"];
       }
       public int DeleteUser(int UserID, string UserName)
       {

           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = " delete from tblUser where UserID=@BookID and UserName=@RName";
           SqlCommand cmd = new SqlCommand(sqlQuery, conn);
           cmd.Parameters.AddWithValue("@UserID", UserID);
           cmd.Parameters.AddWithValue("@UserName", UserName);
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
       public int UpdateUser(string UserName, string Password)
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
           string sqlQuery = "update tblUser SET UserName=@UserName,Password=@password";
           SqlCommand cmd = new SqlCommand(sqlQuery, conn);
           cmd.Parameters.AddWithValue("@UserName", UserName);
           cmd.Parameters.AddWithValue("@Password", Password);
           
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

    }
}
