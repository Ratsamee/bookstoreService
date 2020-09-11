using bookstoreService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace bookstoreService.Data
{
    public class UserAccess: BaseDataAccess
    {
        public UserAccess(string connectionString):base(connectionString)
        {
        }

        public async Task<SignInUser> GetUser(string email, string password)
        {
            var parameters = new List<SqlParameter>
            {
                GetParameterOut("@email", SqlDbType.VarChar, email),
                GetParameterOut("@password", SqlDbType.Text, password)
            };
            var dt = await GetDataReader("sp_getUser", parameters);

            return GetSignInUser(dt);
        }

        public async Task<SignInUser> AddUser(User newUser)
        {
            var parameters = new List<SqlParameter>
            {
                GetParameterOut("@email", SqlDbType.VarChar, newUser.Email),
                GetParameterOut("@password", SqlDbType.VarChar, newUser.Password),
                GetParameterOut("@fullName", SqlDbType.VarChar, newUser.FullName),
                GetParameterOut("@address", SqlDbType.Text, newUser.Address)
            };
            var dt = await GetDataReader("sp_insertUser", parameters);

            return GetSignInUser(dt);
        }

        private SignInUser GetSignInUser(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            var dr = dt.Rows[0];
            var user = new SignInUser
            {
                Id = (int)dr["id"],
                Email = (string)dr["email"],
                FullName = (string)dr["full_name"],
                Address = (dr["address"]).GetType() == typeof(DBNull)? null: dr["address"].ToString()
            };
            return user;
        }
    }
}
