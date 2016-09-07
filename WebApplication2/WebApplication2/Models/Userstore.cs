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
using Dapper;


namespace WebApplication2.Models
{

    public class UserStore :
        IUserStore<User>,
        IUserLoginStore<User>,
        IUserPasswordStore<User>,
        IUserSecurityStampStore<User>
    {
        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ToString();

   
        private readonly string connectionString;

        public UserStore(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
        }

        public  UserStore()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException(); 

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

                try
                {
                    //string conn = ConfigurationManager.ConnectionStrings["JBConnection"].ToString();
                    sqlcon = new SqlConnection(conn);
                    sqlcon.Open();
                    com = new SqlCommand("SignUp");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = sqlcon;
                    da = new SqlDataAdapter(com);
                    com.Parameters.AddWithValue("@uid", user.UserId);
                    com.Parameters.AddWithValue("@empl", user.Role);
                    com.Parameters.AddWithValue("@usnm", user.Email);
                    com.Parameters.AddWithValue("@mail", user.Email);
                    com.Parameters.AddWithValue("@pash", user.PasswordHash);
                    com.Parameters.AddWithValue("@scsp", user.SecurityStamp);
                    com.ExecuteNonQuery();
                }
                catch {
                    sqlcon.Close(); 
                }
            });
        }
        
        public virtual Task DeleteAsync(User user)
        {
            
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    connection.Execute("delete from Users where UserId = @userId", new { user.UserId });
            });
            
            
            //throw new NotImplementedException();
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
             
            //throw new NotImplementedException();
        }




        public virtual Task<User> FindByNameAsync(string userName)
        {

            User usr = new User();

            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            return Task.Factory.StartNew(() =>
            {
        
                 using (SqlConnection com = new SqlConnection(connectionString))
                     return com.Query<User>("GetbyName", new { @usnm = userName }, commandType: CommandType.StoredProcedure).SingleOrDefault();          
                   
            });
             
        }

        public virtual Task UpdateAsync(User user)
        {
            
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("Userupdate");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@uid", user.UserId);
                com.Parameters.AddWithValue("@usnm", user.Email);
                com.Parameters.AddWithValue("@mail", user.Email);
                com.Parameters.AddWithValue("@pash", user.PasswordHash);
                com.Parameters.AddWithValue("@scsp", user.SecurityStamp);
                com.ExecuteNonQuery();
            
            });
             
            throw new NotImplementedException();
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

                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("AddElogin");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                com.Parameters.AddWithValue("@eid", Guid.NewGuid());
                com.Parameters.AddWithValue("@uid", user.UserId);
                
                com.Parameters.AddWithValue("@lpr", login.LoginProvider);
                com.Parameters.AddWithValue("@pky", login.ProviderKey);

                com.ExecuteNonQuery();
            
            
            });
             
            //throw new NotImplementedException();
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
             
            //throw new NotImplementedException();
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
             
            //throw new NotImplementedException();
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
             
           // throw new NotImplementedException();
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

        

    }


}