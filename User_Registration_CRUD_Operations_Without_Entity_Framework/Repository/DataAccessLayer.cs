using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using User_Registration_CRUD_Operations_Without_Entity_Framework.Models;
using User_Registration_CRUD_Operations_Without_Entity_Framework.Models;

namespace User_Registration_CRUD_Operations_Without_Entity_Framework.Repository
{
    public class DataAccessLayer
    {
        public SqlConnection connection = new SqlConnection("conString");


        public List<UserRegistrationModel>  GetDataList()
        {
            List<UserRegistrationModel> list_for_user_registration = new List<UserRegistrationModel>();
            SqlCommand cmd = new SqlCommand("sp_select", connection);
            cmd.CommandType = CommandType.storedProcedure;
            DataTable data_table = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(data_table);

            foreach(DataRow dr in data_table.Rows)
            {
                list_for_user_registration.Add(new UserRegistrationModel { 
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    password_of_user = Convert.ToString(dr[2]),
                    name_of_user = Convert.ToString(dr[3]),
                });
            }



            return list_for_user_registration;
        }


        public bool InsertData(User_Registration_CRUD_Operations_Without_Entity_Framework user_registration)
        {
            SqlCommand cmd = new SqlCommand("sp_insert", connection);
            cmd.CommandType = CommandType.storedProcedure;
            cmd.Parameters.AddWithValue("@id", user_registration.id);
            cmd.Parameters.AddWithValue("@emailid", user_registration.emailid);
            cmd.Parameters.AddWithValue("@password_of_user", user_registration.password_of_user);
            cmd.Parameters.AddWithValue("@name_of_user", user_registration.name_of_user);
            connection.open();
            i = cmd.ExecuteNonQuery();
            connection.close();
            if(i>=1)
                {
                return true;
                }
                else
                {
                    return false;    
                }


        }
    }
}
