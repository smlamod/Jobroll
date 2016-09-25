using System;
using System.Collections;
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
    public partial class ProfilePage : System.Web.UI.Page
    {
        string uid { get; set; }
        public UserManager<User> UserManager { get; private set; }
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string quid = Request.QueryString["uid"];
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (quid == null)
                {
                    uid = Context.User.Identity.GetUserId();
                }
                else
                    uid = quid;

                UserManager = new UserManager<User>(new UserStore());
                var user = UserManager.FindById(uid);
                if (user.Role)
                    Response.Redirect("/Error.aspx?id=2");

                //get uid to display the profile
                
                //FETCH ESSENTIAL MEMBER PROFILE
                string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("MemberCheck");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@uid", uid);
                da.Fill(ds, "MEMBER");
                com.ExecuteNonQuery();

                //REDIRECT HERE IF EMPTY
                if (ds.Tables["MEMBER"].Rows.Count == 0)
                {
                    if (quid == null)
                        Response.Redirect("/Account/EditMemberProfile.aspx");                        
                    else
                        Response.Redirect("/Error.aspx?id=3");
                }
                    

                lfirst.Text = ds.Tables["MEMBER"].Rows[0][4].ToString();
                llast.Text = ds.Tables["MEMBER"].Rows[0][3].ToString();
                lemail.Text = ds.Tables["MEMBER"].Rows[0][15].ToString();
                lloc.Text = ds.Tables["MEMBER"].Rows[0][7].ToString();
                lphone.Text = ds.Tables["MEMBER"].Rows[0][2].ToString();
                llskill.Text = Render_list(ds.Tables["MEMBER"].Rows[0][6].ToString());

                //FETCH EDUCATION DETAILS
                com = new SqlCommand("MemberDegreeGetInfo");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                dt = new DataTable();
                com.Parameters.AddWithValue("@uid", uid);
                da.Fill(dt);
                com.ExecuteNonQuery();
                lvDegree.DataSource = dt;
                lvDegree.DataBind();

                //FETCH EXPERIENCE DETAILS
                com = new SqlCommand("MemberXPGetInfo");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                dt = new DataTable();
                com.Parameters.AddWithValue("@uid", uid);
                da.Fill(dt);
                com.ExecuteNonQuery();
                if (dt.Rows.Count != 0)
                {
                    lvXp.DataSource = dt;
                    lvXp.DataBind();
                }

            }
            else
                Response.Redirect("/Error.aspx");
        }

        protected string Render_list(string str)
        {
            string[] buff = str.Split('\r');
            string render = "";
            foreach (string s in buff)
            {
                render += "<li>";
                render += s;
                render += "</li>";
            }

            return render;
        }

        
        protected void Lvdegree_ItemDatabound (object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                
                Label ledstart = (Label)e.Item.FindControl("ledstart");
                Label ledstop = (Label)e.Item.FindControl("ledstop");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;         
               
                DateTime st = DateTime.Parse(rowView["EduStart"].ToString());
                ledstart.Text = st.ToString("MMMM yyyy");

                if (rowView["EduStop"].ToString() != null)
                {
                    DateTime sp = DateTime.Parse(rowView["EduStop"].ToString());
                    ledstop.Text = sp.ToString("MMMM yyyy");
                }
                else
                    ledstop.Text = "Present";

                Literal lleddesc = (Literal)e.Item.FindControl("lleddesc");
                lleddesc.Text = Render_list(rowView["EduDesc"].ToString());

            }
        }

        protected void LvXP_ItemDataBound (object sende, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DateTime datevalue;
                Label ledstart = (Label)e.Item.FindControl("lxpstart");
                Label ledstop = (Label)e.Item.FindControl("lxpstop");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;

                DateTime st = DateTime.Parse(rowView["XpStart"].ToString());
                ledstart.Text = st.ToString("MMMM yyyy");

                if (DateTime.TryParse(rowView["XpStop"].ToString(), out datevalue))
                {
                    ledstop.Text = datevalue.ToString("MMMM yyyy");
                }
                else
                {
                    ledstop.Text = "Present";
                }

                Literal lleddesc = (Literal)e.Item.FindControl("llxpdesc");
                lleddesc.Text = Render_list(rowView["XpDesc"].ToString());

            }
        }
         
    }
}