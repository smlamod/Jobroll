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
                        tfirst.Text = ds.Tables["MEMBER"].Rows[0][4].ToString();
                        tlast.Text = ds.Tables["MEMBER"].Rows[0][3].ToString();
                        tlocation.Text = ds.Tables["MEMBER"].Rows[0][7].ToString();
                        tphone.Text = ds.Tables["MEMBER"].Rows[0][2].ToString();
                        tskills.Text = ds.Tables["MEMBER"].Rows[0][6].ToString();
                        tsalary.Text = ds.Tables["MEMBER"].Rows[0][8].ToString();

                        //FETCH EXPERIENCE PROFILE
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

                }
            }
 
        }

        protected void EditEdu_Click(object sender, EventArgs e)
        {

        }

        protected void AddDegree_Click(object sender, EventArgs e)
        {

        }
    }
}