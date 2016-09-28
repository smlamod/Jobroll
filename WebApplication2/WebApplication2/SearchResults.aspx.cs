using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WebApplication2
{
    public partial class SearchResults : System.Web.UI.Page
    {
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string qry = Request.QueryString["qry"];
                string sal = Request.QueryString["sal"];
                string loc = Request.QueryString["loc"];

                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    if (qry != null || sal != null || loc != null )
                    {



                        string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                        sqlcon = new SqlConnection(conn);
                        sqlcon.Open();
                        com = new SqlCommand("JobGetName");
                        com.CommandType = CommandType.StoredProcedure;
                        com.Connection = sqlcon;
                        da = new SqlDataAdapter(com);
                        dt = new DataTable();
                        com.Parameters.AddWithValue("@jname", qry);
                        com.Parameters.AddWithValue("@jexp", sal);
                        com.Parameters.AddWithValue("@jloc", loc);
                        da.Fill(dt);
                        com.ExecuteNonQuery();
                        lvJobr.DataSource = dt;
                        lvJobr.DataBind();
                    }
                }
                else
                    Response.Redirect("/Error.aspx?id=4");
            }
        }

        protected void Search_click(object sender, EventArgs e)
        {
            Response.Redirect("/SearchResults?qry=" + tjbsearch.Text +"&sal="+ tsalary.Text + 
               "&loc=" + tlocation.Text);     
        }
    }
}