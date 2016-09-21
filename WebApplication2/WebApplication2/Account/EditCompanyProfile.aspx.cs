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
    public partial class EditCompanyProfile : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        int UserMember { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserManager = new UserManager<User>(new UserStore());
                    var user = UserManager.FindById(Context.User.Identity.GetUserId());
                    if (!user.Role)
                        Response.Redirect("/Error.aspx");

                    //FETCH ESSENTIAL MEMBER PROFILE
                    string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                    sqlcon = new SqlConnection(conn);
                    sqlcon.Open();
                    com = new SqlCommand("CompanyCheck");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = sqlcon;
                    da = new SqlDataAdapter(com);
                    ds = new DataSet();
                    com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
                    da.Fill(ds, "COMPANY");
                    com.ExecuteNonQuery();

                    //LOAD CONTROLS IF COMPANY INFO EXISTS
                    if (ds.Tables["COMPANY"].Rows.Count != 0)
                    {
                        tcphone.Text = ds.Tables["COMPANY"].Rows[0][2].ToString();
                        tcname.Text = ds.Tables["COMPANY"].Rows[0][4].ToString();
                        tcaddr.Text = ds.Tables["COMPANY"].Rows[0][5].ToString();
                        tcover.Text = ds.Tables["COMPANY"].Rows[0][6].ToString();
                        tcjoin.Text = ds.Tables["COMPANY"].Rows[0][7].ToString();
                        tcproc.Text = ds.Tables["COMPANY"].Rows[0][8].ToString();
                        tcindstry.Text = ds.Tables["COMPANY"].Rows[0][9].ToString();
                        tcweb.Text = ds.Tables["COMPANY"].Rows[0][10].ToString();
                        tcsize.Text = ds.Tables["COMPANY"].Rows[0][11].ToString();
                        tcemp.Text = ds.Tables["COMPANY"].Rows[0][12].ToString();
                        tccode.Text = ds.Tables["COMPANY"].Rows[0][13].ToString();
                    }


                }
            }

        }

        protected void DataBind()
        {


        }

        protected void EditCompany_Click(object sender, EventArgs e)
        {
            //FETCH ESSENTIAL MEMBER PROFILE
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            com = new SqlCommand("CompanyCheck");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "COMPANY");
            com.ExecuteNonQuery();

            //IF NO COMPANY DETAILS THEN CREATE
            if (ds.Tables["COMPANY"].Rows.Count == 0)
            {
                com = new SqlCommand("CompanyCreate");
            }
            else //ELSE UPDATE
            {
                com = new SqlCommand("CompanyUpdate");
            }

            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();

            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            com.Parameters.AddWithValue("@pnum", tcphone.Text);
            com.Parameters.AddWithValue("@cname", tcname.Text);
            com.Parameters.AddWithValue("@caddr", tcaddr.Text);
            com.Parameters.AddWithValue("@cover", tcover.Text);
            com.Parameters.AddWithValue("@cjoin", tcjoin.Text);
            com.Parameters.AddWithValue("@cproc", tcproc.Text);
            com.Parameters.AddWithValue("cind", tcindstry.Text);
            com.Parameters.AddWithValue("@cweb", tcweb.Text);
            com.Parameters.AddWithValue("@csize", tcsize.Text);
            com.Parameters.AddWithValue("@cwork", tcemp.Text);
            com.Parameters.AddWithValue("@cdress", tcaddr.Text);
            da.Fill(ds, "COMPANY");
            com.ExecuteNonQuery();

            lmsg.Text = "Basic Information Added/Updated";
        }



    }
}