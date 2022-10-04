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
        //connect with swapnil for reading connection string from appSettings.json
//         public SqlConnection connection = new SqlConnection("TextMVCCOnnectionString");

        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
         
        public DataAcessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("TextMVCCOnnectionString")
        }
        //use var 
        public List<UserRegistrationModel>  GetDataList()
        {
            var ListForUserRegistration = new List<UserRegistrationModel>();
            var  command= new SqlCommand("sp_select", connection);
            command.CommandType = CommandType.storedProcedure;
            var DataTable = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(DataTable);

            foreach(DataRow dr in DataTable.Rows)
            {
                ListForUserRegistration.Add(new UserRegistrationModel { 
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    PasswordOfUser = Convert.ToString(dr[2]),
                    NameOfUser = Convert.ToString(dr[3]),
                });
            }



            return ListForUserRegistration;
        }

        //it should be add data, also add, update should return back updated/added row from table
        public bool InsertData(User_Registration_CRUD_Operations_Without_Entity_Framework UserRegistration)
        {
            var command = new SqlCommand("sp_insert", connection);
            command.CommandType = CommandType.storedProcedure;
            command.Parameters.AddWithValue("@id", UserRegistration.id);
            command.Parameters.AddWithValue("@emailid", UserRegistration.EmailId);
            command.Parameters.AddWithValue("@password_of_user", UserRegistration.PasswordOfUser);
            command.Parameters.AddWithValue("@name_of_user", UserRegistration.NameOfUser);
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
        
         public List<UserRegistrationModel>  GetDataList()
        {
            var ListForUserRegistration = new List<UserRegistrationModel>();
            var  command= new SqlCommand("sp_select", connection);
            command.CommandType = CommandType.storedProcedure;
            var DataTable = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(DataTable);

            foreach(DataRow dr in DataTable.Rows)
            {
                ListForUserRegistration.Add(new UserRegistrationModel { 
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    PasswordOfUser = Convert.ToString(dr[2]),
                    NameOfUser = Convert.ToString(dr[3]),
                });
            }



            return ListForUserRegistration;
        }
    }
}
