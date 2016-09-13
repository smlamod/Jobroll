using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using WebApplication2.Models;
using System.Data;
using System.Collections;

namespace WebApplication2.DAL
{
    

    //THIS CLASS EXTENDS ASP.NET.IDENTITY FOR CUSTOM DATA ACCESS TO DATABASE
    public class UserStore : IUserStore<User>, IUserLoginStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>
    {
        private readonly string conn;

        SqlConnection sqlcon;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand com;
        
        public UserStore(string conn)
        {
            if (string.IsNullOrWhiteSpace(conn))
                throw new ArgumentNullException("conn");

            this.conn = conn;
        }

        public UserStore()
        {
            this.conn = ConfigurationManager.ConnectionStrings["JBConnection"].ConnectionString;
        }

        public void Dispose()
        {

        }

        #region IUserStore
        public virtual Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                user.UserId = Guid.NewGuid();
                using (SqlConnection connection = new SqlConnection(conn))

                    try
                    {
                        sqlcon = new SqlConnection(conn);
                        sqlcon.Open();
                        com = new SqlCommand("UserSignUp");
                        com.CommandType = CommandType.StoredProcedure;
                        com.Connection = sqlcon;
                        com.Parameters.AddWithValue("@uid", user.UserId);
                        com.Parameters.AddWithValue("@empl", user.Role);
                        com.Parameters.AddWithValue("@usnm", user.Email);
                        com.Parameters.AddWithValue("@mail", user.Email);
                        com.Parameters.AddWithValue("@pash", user.PasswordHash);
                        com.Parameters.AddWithValue("@scsp", user.SecurityStamp);
                        com.ExecuteNonQuery();
                    }
                    catch
                    {
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
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserDelete");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                com.Parameters.AddWithValue("@uid", user.UserId);
                com.ExecuteNonQuery();
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
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserGetbyId");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@uid", userId);
                da.Fill(ds, "USER");
                com.ExecuteNonQuery();
                User retUser = new User();
                if (ds.Tables["USER"].Rows.Count != 0)
                {
                    retUser.UserId = new Guid(ds.Tables["USER"].Rows[0][0].ToString());
                    retUser.Role = Convert.ToBoolean(ds.Tables["USER"].Rows[0][1]);
                    retUser.UserName = ds.Tables["USER"].Rows[0][2].ToString();
                    retUser.Email = ds.Tables["USER"].Rows[0][3].ToString();
                    string tmp = ds.Tables["USER"].Rows[0][4].ToString();
                    if (tmp == "")
                        retUser.PasswordHash = null;
                    else
                        retUser.PasswordHash = tmp;
                    retUser.SecurityStamp = ds.Tables["USER"].Rows[0][5].ToString();
                    return retUser;
                }
                else
                    return null;    


            });
        }

        public virtual Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            return Task.Factory.StartNew(() =>
            {
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserGetbyName");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@usnm", userName);
                da.Fill(ds, "USER");
                com.ExecuteNonQuery();
                User retUser = new User();
                if (ds.Tables["USER"].Rows.Count != 0)
                {
                    retUser.UserId = new Guid(ds.Tables["USER"].Rows[0][0].ToString());
                    retUser.Role = Convert.ToBoolean(ds.Tables["USER"].Rows[0][1]);
                    retUser.UserName = ds.Tables["USER"].Rows[0][2].ToString();
                    retUser.Email = ds.Tables["USER"].Rows[0][3].ToString();
                    string tmp = ds.Tables["USER"].Rows[0][4].ToString();
                    if (tmp == "")
                        retUser.PasswordHash = null;
                    else
                        retUser.PasswordHash = tmp;
                    retUser.SecurityStamp = ds.Tables["USER"].Rows[0][5].ToString();
                    return retUser;
                }
                else
                    return null;    
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
                com = new SqlCommand("UserUpdate");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                com.Parameters.AddWithValue("@uid", user.UserId);
                com.Parameters.AddWithValue("@usnm", user.Email);
                com.Parameters.AddWithValue("@mail", user.Email);
                com.Parameters.AddWithValue("@pash", user.PasswordHash);
                com.Parameters.AddWithValue("@scsp", user.SecurityStamp);
                com.ExecuteNonQuery();
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
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserAddElogin");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                com.Parameters.AddWithValue("@eid", Guid.NewGuid());
                com.Parameters.AddWithValue("@uid", user.UserId);
                com.Parameters.AddWithValue("@lpr", login.LoginProvider);
                com.Parameters.AddWithValue("@pky", login.ProviderKey);
                com.ExecuteNonQuery();
                
            });
        }

        public virtual Task<User> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            return Task.Factory.StartNew(() =>
            {
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserGetLogInfo");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@lpr", login.LoginProvider);
                com.Parameters.AddWithValue("@pky", login.ProviderKey);
                da.Fill(ds, "USER");
                com.ExecuteNonQuery();
                User retUser = new User();
                if (ds.Tables["USER"].Rows.Count != 0)
                {
                    retUser.UserId = new Guid(ds.Tables["USER"].Rows[0][0].ToString());
                    retUser.Role = Convert.ToBoolean(ds.Tables["USER"].Rows[0][1]);
                    retUser.UserName = ds.Tables["USER"].Rows[0][2].ToString();
                    retUser.Email = ds.Tables["USER"].Rows[0][3].ToString();
                    string tmp = ds.Tables["USER"].Rows[0][4].ToString();
                    if (tmp == "")
                        retUser.PasswordHash = null;
                    else
                        retUser.PasswordHash = tmp;

                    retUser.SecurityStamp = ds.Tables["USER"].Rows[0][5].ToString();
                    return retUser;
                }
                else
                    return null;    
            });
        }

        public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserGetELogInfo");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                com.Parameters.AddWithValue("@uid", user.UserId);
                da.Fill(ds, "LOGIN");
                com.ExecuteNonQuery();
                UserLoginInfo ulinfo;
                IList newList = new List<UserLoginInfo>();

                for (int x = 0; x < ds.Tables["LOGIN"].Rows.Count; x++)
                {
                    ulinfo = new UserLoginInfo(ds.Tables["LOGIN"].Rows[0][0].ToString(), ds.Tables["LOGIN"].Rows[0][1].ToString());
                    newList.Add(ulinfo);
                }
                return (IList<UserLoginInfo>)newList.Cast<UserLoginInfo>().ToList();
                

                

                //using (SqlConnection connection = new SqlConnection(conn))
                 //   return (IList<UserLoginInfo>)connection.Query<UserLoginInfo>("select LoginProvider, ProviderKey from ExternalLogins where UserId = @userId", new { user.UserId }).ToList();
                
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
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
                com = new SqlCommand("UserRemoveElogin");
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = sqlcon;
                com.Parameters.AddWithValue("@uid", user.UserId);
                com.Parameters.AddWithValue("@lpr", login.LoginProvider);
                com.Parameters.AddWithValue("@pky", login.ProviderKey);
                com.ExecuteNonQuery();
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
    }
}