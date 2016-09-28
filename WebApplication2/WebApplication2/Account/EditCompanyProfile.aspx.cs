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
    public partial class EditCompanyProfile : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        int UserCompany { get; set; }


        protected string GetJobId(int index)
        {
            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            com = new SqlCommand("JobGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(ds, "JOB");
            com.ExecuteNonQuery();
            return ds.Tables["JOB"].Rows[index][0].ToString();  
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserManager = new UserManager<User>(new UserStore());
                    var user = UserManager.FindById(Context.User.Identity.GetUserId());
                    if (!user.Role)
                        Response.Redirect("/Error.aspx?id=2");

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
                        Session["OldFile"] = ds.Tables["COMPANY"].Rows[0][3].ToString();

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
                        
                        //FETCH JOBS
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
            com = new SqlCommand("JobGetInfo");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            com.Parameters.AddWithValue("@uid", Context.User.Identity.GetUserId());
            da.Fill(dt);
            com.ExecuteNonQuery();
            lvJob.DataSource = dt;
            lvJob.DataBind();

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

            if (fupload.HasFile)
            {
                string fileName = Path.GetFileName(fupload.PostedFile.FileName);
                string[] buff = fileName.Split('.');
                string render = "";
                int x = 0;
                foreach (string s in buff)
                {
                    if (x != 0)
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

        protected void AddJob_Click (object sender, EventArgs e)
        {

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
            UserCompany = int.Parse(ds.Tables["COMPANY"].Rows[0][0].ToString());

            com = new SqlCommand("JobCreate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;

            com.Parameters.AddWithValue("@cid", UserCompany);
            com.Parameters.AddWithValue("@jname", tjbName.Text);
            com.Parameters.AddWithValue("@jdesc", tjbDesc.Text);
            com.Parameters.AddWithValue("@jreqt", tjbReqt.Text);
            com.Parameters.AddWithValue("@jloc", tjbLoc.Text);
            com.Parameters.AddWithValue("@jexp", tjbExp.Text);
            com.Parameters.AddWithValue("@jpub", cjbPub.Checked);
            com.ExecuteNonQuery();
            lmsg.Text = "Job Added Added";

            DataBind();
        }

        protected void LvJob_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int JobId = int.Parse(GetJobId(e.ItemIndex));

            TextBox tjbName = ((TextBox)lvJob.Items[e.ItemIndex].FindControl("tjbName"));
            TextBox tjbDesc = ((TextBox)lvJob.Items[e.ItemIndex].FindControl("tjbDesc"));
            TextBox tjbReqt = ((TextBox)lvJob.Items[e.ItemIndex].FindControl("tjbReqt"));
            TextBox tjbLoc = ((TextBox)lvJob.Items[e.ItemIndex].FindControl("tjbLoc"));
            TextBox tjbExp = ((TextBox)lvJob.Items[e.ItemIndex].FindControl("tjbExp"));
            CheckBox cjbPub = ((CheckBox)lvJob.Items[e.ItemIndex].FindControl("cjbPub"));


            string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
            sqlcon = new SqlConnection(conn);
            sqlcon.Open();

            com = new SqlCommand("JobUpdate");
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = sqlcon;
            da = new SqlDataAdapter(com);
            ds = new DataSet();

            com.Parameters.AddWithValue("@jid", JobId);
            com.Parameters.AddWithValue("@jname", tjbName.Text);
            com.Parameters.AddWithValue("@jdesc", tjbDesc.Text);
            com.Parameters.AddWithValue("@jreqt", tjbReqt.Text);
            com.Parameters.AddWithValue("@jloc", tjbLoc.Text);
            com.Parameters.AddWithValue("@jexp", tjbExp.Text);
            com.Parameters.AddWithValue("@jpub", cjbPub.Checked);

            com.ExecuteNonQuery();

            lmsg.Text = "Job Updated";

            lvJob.EditIndex = -1;
            DataBind();
        }


        protected void LvJob_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            lvJob.EditIndex = e.NewEditIndex;
            DataBind();
        }

        protected void LvJob_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lvJob.EditIndex = -1;
            DataBind();
        }

        protected void LvJob_ItemDelete(object sender, ListViewDeleteEventArgs e)
        {
            int JobId = int.Parse(GetJobId(e.ItemIndex));
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("JobRemove");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@jid", JobId);
                com.ExecuteNonQuery();
                lmsg.Text = "Job Removed";

                lvJob.EditIndex = -1;
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