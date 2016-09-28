using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebApplication2.DAL;
using WebApplication2.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication2.Account
{
    public partial class EditMemberProfile : System.Web.UI.Page
    {
                public UserManager<User> UserManager { get; private set; }
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        int UserMember { get; set; }
        string fileName { get; set; }
        string oldfileName { get; set; }

        protected void EditMember_Click (object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            com = new SqlCommand("MemberCheck");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "MEMBER");
            com.ExecuteNonQuery();

            //IF NO MEMBER DETAILS THEN CREATE
            if (ds.Tables["MEMBER"].Rows.Count == 0)
            {
                com = new SqlCommand("MemberCreate");
            }
            else //ELSE UPDATE
            {
                com = new SqlCommand("MemberUpdate");
            }
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            com.Parameters.AddWithValue("@pnum", tphone.Text);
            com.Parameters.AddWithValue("@lname", tlast.Text);
            com.Parameters.AddWithValue("@fname", tfirst.Text);


            if (fupload.HasFile)
            {
                fileName = Path.GetFileName(fupload.PostedFile.FileName);
                //fileName = Guid.NewGuid().ToString();
               

                string[] buff = fileName.Split('.');
                string render = "";
                int x = 0;
                foreach (string s in buff)
                {
                    if (x !=0)
                    {
                        render += Guid.NewGuid();
                        render += '.';
                        render += s;
                    }
                    x++;
                }
                fupload.PostedFile.SaveAs(Server.MapPath("/img/dp/") + render);
                com.Parameters.AddWithValue("@dpic", "\\img\\dp\\" + render);
            }
            else
            {
                if (string.IsNullOrEmpty(Session["OldFile"] as string))
                {
                com.Parameters.AddWithValue("@dpic", DBNull.Value);
                }
                else
                    com.Parameters.AddWithValue("@dpic", Session["OldFile"]);
            }
            
            com.Parameters.AddWithValue("@skls", tskills.Text);
            com.Parameters.AddWithValue("@salry", tsalary.Text);
            com.Parameters.AddWithValue("@loc", tlocation.Text);

            da.Fill(ds, "MEMBER");
            com.ExecuteNonQuery();

            lmsg.Text = "Basic Information Added/Updated";

        }

        protected void Page_Load (object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserManager = new UserManager<User>(new UserStore());
                    var user = UserManager.FindById(Context.User.Identity.GetUserId());
                    if (user.Role)
                        Response.Redirect("/Error.aspx?id=2");

                    lmsg.Text = "";
                    //FETCH ESSENTIAL MEMBER PROFILE
                    string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                    sqlcon = new SqlConnection(conn);
                    sqlcon.Open();
                    com = new SqlCommand("MemberCheck");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = sqlcon;
                    da = new SqlDataAdapter(com);
                    ds = new DataSet();
                    com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
                    da.Fill(ds, "MEMBER");
                    com.ExecuteNonQuery();

                    //LOAD CONTROLS IF THERE ARE ENTRIES IF NOT LEAVE CONTROLS EMPTY
                    if (ds.Tables["MEMBER"].Rows.Count != 0)
                    {
                        //FETCH INFO PROFILE
                        UserMember = int.Parse( ds.Tables["MEMBER"].Rows[0][0].ToString());
                        tfirst.Text = ds.Tables["MEMBER"].Rows[0][4].ToString();
                        tlast.Text = ds.Tables["MEMBER"].Rows[0][3].ToString();
                        tlocation.Text = ds.Tables["MEMBER"].Rows[0][7].ToString();
                        tphone.Text = ds.Tables["MEMBER"].Rows[0][2].ToString();
                        tskills.Text = ds.Tables["MEMBER"].Rows[0][6].ToString();
                        tsalary.Text = ds.Tables["MEMBER"].Rows[0][8].ToString();
                        Session["OldFile"] = ds.Tables["MEMBER"].Rows[0][5].ToString();

                        //FETCH EXPERIENCE PROFILE
                        DataBind();
                    }

                }
                else
                    Response.Redirect("/Error.aspx?id=4");
            }
 
        }


        protected void DataBind()
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            com = new SqlCommand("MemberDegreeGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(dt);
            com.ExecuteNonQuery();
            lvDegree.DataSource = dt;
            lvDegree.DataBind();

            com = new SqlCommand("MemberXPGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(dt);
            com.ExecuteNonQuery();
                lvXp.DataSource = dt;
                lvXp.DataBind();

        }

        protected string GetDegreeID(int index)
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            com = new SqlCommand("MemberDegreeGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds,"DEGREE");
            com.ExecuteNonQuery();
            return ds.Tables["DEGREE"].Rows[index][0].ToString();   
        }

        protected string GetXpID(int index)
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            com = new SqlCommand("MemberXPGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "XP");
            com.ExecuteNonQuery();
            return ds.Tables["XP"].Rows[index][0].ToString();  

        }

        protected void AddDegree_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            com = new SqlCommand("MemberCheck");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "MEMBER");
            com.ExecuteNonQuery();
            UserMember = int.Parse(ds.Tables["MEMBER"].Rows[0][0].ToString());

            com = new SqlCommand("MemberDegreeCreate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;

            com.Parameters.AddWithValue("@mid", UserMember);
            com.Parameters.AddWithValue("@est", teduStart.Text);
            com.Parameters.AddWithValue("@esp", teduStop.Text);
            com.Parameters.AddWithValue("@edg", tedudegree.Text);
            com.Parameters.AddWithValue("@esh", teduschool.Text);
            com.Parameters.AddWithValue("@ecy", teducity.Text);
            com.Parameters.AddWithValue("@este",tedustate.Text);
            com.Parameters.AddWithValue("@edsc", tedudesc.Text);
            com.ExecuteNonQuery();

            lmsg.Text = "Degree Added";
            DataBind();
        }

        
        protected void Lvdegree_ItemDatabound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                TextBox teduStart = (TextBox)e.Item.FindControl("teduStart");
                TextBox teduStop = (TextBox)e.Item.FindControl("teduStop");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;

                DateTime st = DateTime.Parse(rowView["EduStart"].ToString());
                teduStart.Text = st.ToString("yyyy-MM-dd");

                DateTime sp = DateTime.Parse(rowView["EduStop"].ToString());
                teduStop.Text = sp.ToString("yyyy-MM-dd");

            }
        }

        protected void Lvdegree_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int DegreeId = int.Parse(GetDegreeID(e.ItemIndex));

            TextBox teduStart = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("teduStart"));
            TextBox teduStop = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("teduStop"));
            TextBox teduDegree = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("teduDegree"));
            TextBox teduschool = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("teduschool"));
            TextBox teducity = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("teducity"));
            TextBox tedustate = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("tedustate"));
            TextBox tedudesc = ((TextBox)lvDegree.Items[e.ItemIndex].FindControl("tedudesc"));

            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            com = new SqlCommand("MemberDegreeUpdate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@did", DegreeId);
            com.Parameters.AddWithValue("@est", teduStart.Text);
            com.Parameters.AddWithValue("@esp", teduStop.Text);
            com.Parameters.AddWithValue("@edg", teduDegree.Text);
            com.Parameters.AddWithValue("@esh", teduschool.Text);
            com.Parameters.AddWithValue("@ecy", teducity.Text);
            com.Parameters.AddWithValue("@este", tedustate.Text);
            com.Parameters.AddWithValue("@edsc", tedudesc.Text);

            com.ExecuteNonQuery();

            lmsg.Text = "Degree Updated";

            lvDegree.EditIndex = -1;
            DataBind();
        }

        protected void Lvdegree_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lvDegree.EditIndex = -1;
            DataBind();
        }

        protected void Lvdegree_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvDegree.EditIndex = e.NewEditIndex;
            DataBind();
        }

        protected void Lvdegree_ItemDelete(object sender, ListViewDeleteEventArgs e)
        {
            int DegreeId = int.Parse(GetDegreeID(e.ItemIndex));
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("MemberDegreeRemove");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@did", DegreeId);
                com.ExecuteNonQuery();
                lmsg.Text = "Degree Removed";

                lvDegree.EditIndex = -1;
                DataBind();

            }
            catch (Exception)
            {
                lmsg.Text = "An Error Occured";
                throw;
            }

        }

        protected void AddExperience_Click(object sender, EventArgs e)
        {
            DateTime datevalue;
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            
            com = new SqlCommand("MemberCheck");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "MEMBER");
            com.ExecuteNonQuery();
            UserMember = int.Parse(ds.Tables["MEMBER"].Rows[0][0].ToString());

            com = new SqlCommand("MemberXPCreate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;

            com.Parameters.AddWithValue("@mid", UserMember);
            com.Parameters.AddWithValue("@xst", txpStart.Text);

            if (DateTime.TryParse(txpStop.Text, out datevalue))
            {
                com.Parameters.AddWithValue("@xsp", datevalue.ToString("yyyy-MM-dd"));
            }
            else
            {
                com.Parameters.AddWithValue("@xsp", DBNull.Value);
            }
            
            com.Parameters.AddWithValue("@xpos", txpPosition.Text);
            com.Parameters.AddWithValue("@xcom", txpCompany.Text);
            com.Parameters.AddWithValue("@xcy", txpcity.Text);
            com.Parameters.AddWithValue("@xste", txpstate.Text);
            com.Parameters.AddWithValue("@xdsc", txpdesc.Text);
            com.ExecuteNonQuery();

            lmsg.Text = "Experience Added";
            DataBind();

        }

        protected void LvXP_ItemDataBound(object sende, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DateTime datevalue;
                TextBox txpStart = (TextBox)e.Item.FindControl("txpStart");
                TextBox txpStop = (TextBox)e.Item.FindControl("txpStop");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;

                DateTime st = DateTime.Parse(rowView["XpStart"].ToString());
                txpStart.Text = st.ToString("yyyy-MM-dd");


                if (DateTime.TryParse(rowView["XpStop"].ToString(), out datevalue))
                {
                    txpStop.Text = datevalue.ToString("yyyy-MM-dd");
                }
                else
                {
                    txpStop.Text = null;
                }

            }
        }

        protected void LvXP_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int XPid = int.Parse(GetXpID(e.ItemIndex));
            DateTime datevalue;

            TextBox txpStart = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpStart"));
            TextBox txpStop = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpStop"));
            TextBox txpPosition = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpPosition"));
            TextBox txpCompany = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpCompany"));
            TextBox txpcity = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpcity"));
            TextBox txpstate = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpstate"));
            TextBox txpdesc = ((TextBox)lvXp.Items[e.ItemIndex].FindControl("txpdesc"));

            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            com = new SqlCommand("MemberXPUpdate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@xid", XPid);
            com.Parameters.AddWithValue("@xst", txpStart.Text);
            if (DateTime.TryParse(txpStop.Text, out datevalue))
            {
                com.Parameters.AddWithValue("@xsp", datevalue.ToString());
            }
            else
            {
                com.Parameters.AddWithValue("@xsp", DBNull.Value);
            }
            com.Parameters.AddWithValue("@xpos", txpPosition.Text);
            com.Parameters.AddWithValue("@xcom", txpCompany.Text);
            com.Parameters.AddWithValue("@xcy", txpcity.Text);
            com.Parameters.AddWithValue("@xste", txpstate.Text);
            com.Parameters.AddWithValue("@xdsc", txpdesc.Text);
            com.ExecuteNonQuery();

            lmsg.Text = "Experience Updated";
            lvDegree.EditIndex = -1;
            DataBind();
        }

        protected void LvXP_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvXp.EditIndex = e.NewEditIndex;
            DataBind();
        }

        protected void LvXp_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lvXp.EditIndex = -1;
            DataBind();
        }

        protected void LvXp_ItemDelete(object sender, ListViewDeleteEventArgs e)
        {
            int XPid = int.Parse(GetXpID(e.ItemIndex));
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("MemberXPRemove");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@xid", XPid);

                com.ExecuteNonQuery();
                lmsg.Text = "Degree Removed";

                lvDegree.EditIndex = -1;
                DataBind();

            }
            catch (Exception)
            {
                lmsg.Text = "An Error Occured";
                throw;
            }
        }

    }
}