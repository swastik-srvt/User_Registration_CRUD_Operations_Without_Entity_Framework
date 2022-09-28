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
            var  command= new SqlCommand("sp_select", connection);
            command.CommandType = CommandType.storedProcedure;
            var data_table = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data_table);

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
            var command = new SqlCommand("sp_insert", connection);
            command.CommandType = CommandType.storedProcedure;
            command.Parameters.AddWithValue("@id", user_registration.id);
            command.Parameters.AddWithValue("@emailid", user_registration.emailid);
            command.Parameters.AddWithValue("@password_of_user", user_registration.password_of_user);
            command.Parameters.AddWithValue("@name_of_user", user_registration.name_of_user);
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
