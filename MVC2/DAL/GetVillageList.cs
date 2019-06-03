using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVC2.Models;

namespace MVC2.DAL
{
    public class GetVillageList
    {
        public List<Gamer> GetList(string id)
        {
            try
            {

                string sqlConnectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["OnlineGameDBContext"].ConnectionString;

                //string sql = @" SELECT `VillageId`, `Village` FROM `Village`";
                string sql = "SELECT * FROM [OnlineGame].[dbo].[Gamer] where Id=@Id;";

                List<Gamer> list = new List<Gamer>();

                //"SELECT OrderID, CustomerID FROM dbo.Orders;";

                using (SqlConnection connection = new SqlConnection(
                           sqlConnectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Gamer data = new Gamer();
                            data.Id = int.Parse(dr["Id"].ToString());
                            data.Name = dr["Name"].ToString();
                            list.Add(data);
                        }
                    }
                }

                ////防範sql injection,將insert的值更改為參數
                //string sql =
                //    "insert into List_WorkMatters(FormNo,OldFormNo,MainFormNo,ApplyManNo,Title,Owner,Coworker,Priority,IsProject,StartDate,EndDate,EstimatedDate,Status,Notes,CreateDate,Creator) values(@FormNo,@OldFormNo,@MainFormNo,@ApplyManNo,@Title,@Owner,@Coworker,@Priority,@IsProject,@StartDate,@EndDate,@EstimatedDate,@Status,@Notes,@CreateDate,@Creator)";


                //using (SqlConnection con = new SqlConnection(sqlConnectionString))
                //{
                //    using (SqlCommand cmd = new SqlCommand())
                //    {
                //        cmd.Connection = con;
                //        cmd.CommandText = sql;
                //        con.Open();

                //        //利用迴圈將篩選過的資料逐筆insert至sql中
                //        for (int i = 0; i <= (workList.Table.Rows.Count - 1); i++)
                //        {
                //            cmd.Parameters.Clear();
                //            //防範sql injection,將insert的值更改為參數
                //            var SubDocNo = getSubDocNo.getSubDocNo(subdoctype);
                //            cmd.Parameters.AddWithValue("@FormNo", SubDocNo);
                //            cmd.Parameters.AddWithValue("@MainFormNo", FormNo.Text);
                //            cmd.Parameters.AddWithValue("@OldFormNo", workList.Table.Rows[i]["FormNo"].ToString());
                //            cmd.Parameters.AddWithValue("@ApplyManNo", workList.Table.Rows[i]["ApplyManNo"].ToString());
                //            cmd.Parameters.AddWithValue("@Title", workList.Table.Rows[i]["Title"].ToString());
                //            cmd.Parameters.AddWithValue("@Owner", workList.Table.Rows[i]["Owner"].ToString());
                //            cmd.Parameters.AddWithValue("@Coworker", workList.Table.Rows[i]["Coworker"].ToString());
                //            cmd.Parameters.AddWithValue("@Priority", workList.Table.Rows[i]["Priority"].ToString());
                //            cmd.Parameters.AddWithValue("@IsProject", workList.Table.Rows[i]["IsProject"].ToString());
                //            cmd.Parameters.AddWithValue("@StartDate", workList.Table.Rows[i]["StartDate"]);
                //            cmd.Parameters.AddWithValue("@EndDate", workList.Table.Rows[i]["EndDate"]);
                //            cmd.Parameters.AddWithValue("@EstimatedDate", workList.Table.Rows[i]["EstimatedDate"]);
                //            cmd.Parameters.AddWithValue("@Status", workList.Table.Rows[i]["Status"].ToString());
                //            cmd.Parameters.AddWithValue("@Notes", workList.Table.Rows[i]["Notes"].ToString());
                //            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                //            cmd.Parameters.AddWithValue("@Creator", UserID);
                //            cmd.ExecuteNonQuery();
                //        }

                //        //cmd.Parameters.AddWithValue("@text", txtInsert_TEXT.Text);

                //        //cmd.ExecuteNonQuery();
                //        con.Close();
                //        //ScriptManager.RegisterStartupScript(Page, GetType(), "test",
                //        //    "<script>test()</script>",
                //        //    false);
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "確認",
                //            "alert('匯入成功!!')", true);
                //    }
                //}
                return list;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
            //    finally
            //    {

            //    }
            //}
        }
    }
}