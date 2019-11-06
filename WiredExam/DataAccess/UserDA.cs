using DataConnection;
using DataModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserDA
    {
        public UserModel LoginControl(string Username, string Password)
        {

            UserModel udt = new UserModel();

            DBUtilities utility = new DBUtilities();
            utility.cn.Open();
            utility.cmd.CommandText = "select * from Users WHERE Username='" + Username + "' and Password='" + Password+"'";
            SqliteDataReader dr = utility.cmd.ExecuteReader();
            udt.Statu = -1;
            while (dr.Read())
            {
                if (dr["Username"].ToString().Trim() == Username && dr["Password"].ToString().Trim() == Password)
                {
                    udt.Username = dr["Username"].ToString().Trim();
                    udt.Password = dr["Password"].ToString().Trim();
                    udt.Statu = Convert.ToInt32(dr["Statu"]);
                    udt.ID = Convert.ToInt32(dr["ID"]);
                }
                
            }

            if (dr.HasRows == false)
            {
                udt.Username = "Hata";
                udt.Password = "Hata";
                udt.Statu = 1;
            }
            

            dr.Close();
            utility.endC();
            return udt;
        }
    }
}
