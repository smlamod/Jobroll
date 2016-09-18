using System;
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
                        Response.Redirect("/Error.aspx");

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

                        //FETCH EXPERIENCE PROFILE
                        DataBind();
                    }

                }
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

            da.Fill(ds, "DEGREE");
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
                da.Fill(ds, "DEGREE");
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