using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebApplication2.DAL;

namespace WebApplication2.Account
{
    public partial class EditMemberProfile : System.Web.UI.Page
    {
        protected void EditMember_Click (object sender, EventArgs e)
        {
            /*
            string usrid = User.Identity.GetUserId();
            using (var context = new JobrollContext())
            {
                var jmember = context.Members.First(a => a.UserId == usrid);
                jmember.FirstMidName = tfirst.Text;
                jmember.LastName = tlast.Text;
                context.SaveChanges();
            }
             */
        }

        protected void Page_Load (object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

            //    string usrid = User.Identity.GetUserId();
            //    using (var context = new JobrollContext())
            //    {
            //        var jmember = context.Members.First(a => a.UserId == usrid);
            //        tfirst.Text = jmember.FirstMidName;
            //        tlast.Text = jmember.LastName;

            //    }
            //}
        }
    }
}