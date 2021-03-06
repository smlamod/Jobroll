﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;
using WebApplication2.DAL;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication2.Account
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
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

                //REDIRECT HERE IF EMPTY
                if (ds.Tables["COMPANY"].Rows.Count == 0)
                    Response.Redirect("/Account/EditCompanyProfile.aspx");
                
                lphone.Text = ds.Tables["COMPANY"].Rows[0][2].ToString();
                lcomp.Text = ds.Tables["COMPANY"].Rows[0][4].ToString();
                ldress.Text = ds.Tables["COMPANY"].Rows[0][5].ToString();
                lover.Text = ds.Tables["COMPANY"].Rows[0][6].ToString();
                ljoin.Text = ds.Tables["COMPANY"].Rows[0][7].ToString();
                lpoc.Text = ds.Tables["COMPANY"].Rows[0][8].ToString();
                lindustry.Text = ds.Tables["COMPANY"].Rows[0][9].ToString();
                lweb.Text = ds.Tables["COMPANY"].Rows[0][10].ToString();
                lsize.Text = ds.Tables["COMPANY"].Rows[0][11].ToString();
                lemp.Text = ds.Tables["COMPANY"].Rows[0][12].ToString();
                ldress.Text = ds.Tables["COMPANY"].Rows[0][13].ToString();
            }
            else
                Response.Redirect("/Error.aspx");
                
        }
    }
}