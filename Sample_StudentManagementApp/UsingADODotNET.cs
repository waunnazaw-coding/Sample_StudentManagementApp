using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_StudentManagementApp
{
    public class UsingAdo
    {
        private readonly string _connectionString = "Data Source = . ; Initial Catalog = SampleStudentManagement; User ID = sa; Password = waunnazaw ";

        public void Read()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                string query = @"SELECT [StudentId]
                          ,[StudentName]
                          ,[PhoneNum]
                          ,[ClassName]
                          ,[DeleteFlag]
                      FROM [dbo].[StudentTable] where DeleteFlag = 0";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Student Id => {reader["StudentId"]}");
                    Console.WriteLine($"Student Name => {reader["StudentName"]}");
                    Console.WriteLine($"Student Phone Number => {reader["PhoneNum"]}");
                    Console.WriteLine($"Class Name => {reader["ClassName"]}");
                }

                sqlConnection.Close();
            }
            catch( Exception ex )
            {
                Console.WriteLine($"An error occured. {ex.Message}");
            }

        }

        public void Create ()
        {
            //User Inputs for Add new Student 
            Console.Write("Enter Name : ");
            string studentName = Console.ReadLine();

            //Check for Null or empty errors
            if (string.IsNullOrEmpty(studentName))
            {
                Console.WriteLine("Name cannot be empty or null");
                return;
            }

            Console.Write("Enter Phone Number : ");
            string phNum = Console.ReadLine();
            //Check for Null or empty errors
            if (string.IsNullOrEmpty(phNum))
            {
                Console.WriteLine("Phone number cannot be empty or null");
                return;
            }

            Console.Write("Enter Class Name : ");
            string className = Console.ReadLine();

            //Check for Null or empty errors
            if (string.IsNullOrEmpty(className))
            {
                Console.WriteLine("Name cannot be empty or null");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                //Create or Insert into The database
                string query = @"INSERT INTO [dbo].[StudentTable]
                               ([StudentName]
                               ,[PhoneNum]
                               ,[ClassName]
                               ,[DeleteFlag])
                         VALUES
                               (@StudentName ,
                                @PhoneNum ,
                                @ClassName ,
                                0)";

                SqlCommand command = new SqlCommand (query, sqlConnection);
                command.Parameters.AddWithValue("@StudentName " , studentName); // prevent for SqlInjection
                command.Parameters.AddWithValue("@PhoneNum " , phNum); // prevent for SqlInjection
                command.Parameters.AddWithValue("@ClassName " , className); // prevent for SqlInjection

                int result = command.ExecuteNonQuery();
                Console.WriteLine(result == 1 ? "Creating Successfully" : "Creating Fail.");


            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occured.{ex.Message}");
            }
        }

        public void Edit()
        {
            Console.Write("Enter Id : ");
            if (!int.TryParse(Console.ReadLine(), out int editId))
            {
                Console.WriteLine("Invaild Input:");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                string query = @"SELECT [StudentId]
                          ,[StudentName]
                          ,[PhoneNum]
                          ,[ClassName]
                          ,[DeleteFlag]
                      FROM [dbo].[StudentTable] where StudentId = @StudentId";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@StudentId" , editId);
                SqlDataAdapter adapter = new SqlDataAdapter(command); //SqlReader cannot updtat so use SqlDataAdapter
                DataTable dt = new DataTable(); // A single table in memory
                adapter.Fill(dt);

                sqlConnection.Close();

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Could not found data.");
                    return;
                }

                DataRow dr = dt.Rows[0];
                Console.WriteLine($"Student Id => {dr["StudentId"]}");
                Console.WriteLine($"Student Name => {dr["StudentName"]}");
                Console.WriteLine($"Student Phone Number => {dr["PhoneNum"]}");
                Console.WriteLine($"Class Name => {dr["ClassName"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured. {ex.Message}");
            }

        }

        public void Update()
        {
            Console.Write("Enter Id : ");
            if (int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Input not invaild");
                return ;
            }
            //User Inputs for Add new Student 
            Console.Write("Enter Name : ");
            string updateStudentName = Console.ReadLine();

            //Check for Null or empty errors
            if (string.IsNullOrEmpty(updateStudentName))
            {
                Console.WriteLine("Name cannot be empty or null");
                return;
            }

            Console.Write("Enter Phone Number : ");
            string updatePhNum = Console.ReadLine();
            //Check for Null or empty errors
            if (string.IsNullOrEmpty(updatePhNum))
            {
                Console.WriteLine("Phone number cannot be empty or null");
                return;
            }

            Console.Write("Enter Class Name : ");
            string updateClassName = Console.ReadLine();

            //Check for Null or empty errors
            if (string.IsNullOrEmpty(updateClassName))
            {
                Console.WriteLine("Class Name cannot be empty or null");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                //Create or Insert into The database
                string query = @"UPDATE [dbo].[StudentTable]
                               SET [StudentName] = @StudentId 
                                  ,[PhoneNum] = @PhoneNum 
                                  ,[ClassName] = @ClassName
                                  ,[DeleteFlag] = 0
                             WHERE StudentId = @StudentId";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@StudentName ", updateStudentName); // prevent for SqlInjection
                command.Parameters.AddWithValue("@PhoneNum ", updatePhNum); // prevent for SqlInjection
                command.Parameters.AddWithValue("@ClassName ", updateClassName); // prevent for SqlInjection
                command.Parameters.AddWithValue("@StudentId ", updateId); // prevent for SqlInjection

                int result = command.ExecuteNonQuery();
                Console.WriteLine(result == 1 ? "Updating Successfully" : "Updating Fail.");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured.{ex.Message}");
            }
        }

        public void Delete()
        {
            Console.Write("Enter Id : ");
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Input not invaild.");
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                string query = @"DELETE FROM [dbo].[StudentTable]
                                WHERE StudentId = @StudentId";

                SqlCommand deleteCommand = new SqlCommand(query, sqlConnection);
                deleteCommand.Parameters.AddWithValue("@StudentId", deleteId);
                
                int result = deleteCommand.ExecuteNonQuery();
                Console.WriteLine(result == 1 ? "Delete Successfully." : "Delete fail.");

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured. {ex.Message}");
            }
        }
    }
}
