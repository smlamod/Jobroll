using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Models
{
    public class Userstore :
        IUserStore<JBUser>,
        IUserLoginStore<JBUser>,
        IUserPasswordStore<JBUser>,
        IUserSecurityStampStore<JBUser>
    {
        SqlConnection sqlcon;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand com;

        private string connectionString;

        public void UserStore(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
        }

        public void UserStore()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
        }

        #region IUserStore
        public virtual Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                user.UserId = Guid.NewGuid();
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //   connection.Execute("insert into Users(UserId, UserName, PasswordHash, SecurityStamp) values(@userId, @userName, @passwordHash, @securityStamp)", user);

                
                string conn = ConfigurationManager.ConnectionStrings["DB"].ToString();
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("SignUp"); //new SqlCommand("DECLARE @NPID AS INT go SET @NPID = (SELECT MAX(PID) FROM Person)+1 go INSERT INTO Person VALUES (@NPID,@name,@username,@password,@bday,@gender,@email,@address) go");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@uid", TextBox1.Text);
                com.Parameters.AddWithValue("@empl", TextBox2.Text);
                com.Parameters.AddWithValue("@mail", TextBox3.Text);
                com.Parameters.AddWithValue("@pash", bday);
                com.Parameters.AddWithValue("@scsp", gender);
                com.ExecuteNonQuery();



            });
        }
        #endregion

        /*
        public virtual Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("delete from Users where UserId = @userId", new { user.UserId });
            });
        }

        public virtual Task<User> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            Guid parsedUserId;
            if (!Guid.TryParse(userId, out parsedUserId))
                throw new ArgumentOutOfRangeException("userId", string.Format("'{0}' is not a valid GUID.", new { userId }));

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<User>("select * from Users where UserId = @userId", new { userId = parsedUserId }).SingleOrDefault();
            });
        }

        public virtual Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<User>("select * from Users where lower(UserName) = lower(@userName)", new { userName }).SingleOrDefault();
            });
        }

        public virtual Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("update Users set UserName = @userName, PasswordHash = @passwordHash, SecurityStamp = @securityStamp where UserId = @userId", user);
            });
        }
        #endregion

        #region IUserLoginStore
        public virtual Task AddLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (login == null)
                throw new ArgumentNullException("login");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("insert into ExternalLogins(ExternalLoginId, UserId, LoginProvider, ProviderKey) values(@externalLoginId, @userId, @loginProvider, @providerKey)",
                        new { externalLoginId = Guid.NewGuid(), userId = user.UserId, loginProvider = login.LoginProvider, providerKey = login.ProviderKey });
            });
        }

        public virtual Task<User> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<User>("select u.* from Users u inner join ExternalLogins l on l.UserId = u.UserId where l.LoginProvider = @loginProvider and l.ProviderKey = @providerKey",
                        login).SingleOrDefault();
            });
        }

        public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return (IList<UserLoginInfo>)connection.Query<UserLoginInfo>("select LoginProvider, ProviderKey from ExternalLogins where UserId = @userId", new { user.UserId }).ToList();
            });
        }

        public virtual Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (login == null)
                throw new ArgumentNullException("login");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("delete from ExternalLogins where UserId = @userId and LoginProvider = @loginProvider and ProviderKey = @providerKey",
                        new { user.UserId, login.LoginProvider, login.ProviderKey });
            });
        }
        #endregion

        #region IUserPasswordStore
        public virtual Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PasswordHash);
        }

        public virtual Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public virtual Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        #endregion

        #region IUserSecurityStampStore
        public virtual Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.SecurityStamp);
        }

        public virtual Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }

        #endregion

        */

    }


}