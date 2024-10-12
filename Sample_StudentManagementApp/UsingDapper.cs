using Dapper;
using Sample_StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_StudentManagementApp
{
    public class UsingDapper
    {
        private readonly string _connectionString = "Data Source = . ; Initial Catalog = SampleStudentManagement; User ID = sa; Password = waunnazaw ";

        public void Read()
        {

           using (IDbConnection db = new SqlConnection(_connectionString ))
            {
                string query = "SELECT * FROM StudentTable WHERE DeleteFlag = 0";
                var lst = db.Query<StudentDataModelDapper>(query).ToList();
                foreach ( var item in lst )
                {
                    Console.WriteLine("----- Student Information -----");
                    Console.WriteLine($"Student Id => {item.StudentId}");
                    Console.WriteLine($"Student Name => {item.StudentName}");
                    Console.WriteLine($"Student Phone Number => {item.PhoneNum}");
                    Console.WriteLine($"Student Class Name => {item.ClassName}");
                    //Console.WriteLine($"Student Id => {item.StuentId}");
                }
            }
        }

        public void Create ()
        {
            //Input for Creat new student
            Console.Write("Enter Name : " + "\n");
            string studentName = Console.ReadLine();    

            Console.Write("Enter Phone Number : \n");
            string phNum = Console.ReadLine();

            Console.Write("Enter Calss Name :  \n");
            string className = Console.ReadLine();

            //checked Null or Empty
            if (string.IsNullOrEmpty(studentName))
            {
                Console.WriteLine("Student name can not be null or empty.");
                return;
            }

            if (string.IsNullOrEmpty(phNum))
            {
                Console.WriteLine("Phone Number can not be null or empty.");
                return;
            }

            if (string.IsNullOrEmpty(className))
            {
                Console.WriteLine("Class Name cannot be null or empty.");
                return;
            }

            string query = @"INSERT INTO [dbo].[StudentTable]
           ([StudentName]
           ,[PhoneNum]
           ,[ClassName]
           ,[DeleteFlag])
     VALUES
           (@StudentName ,
            @PhoneNum ,
            @ClassName ,
            0
            )";
            
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    int result = db.Execute(query, new StudentDataModelDapper
                    {
                        StudentName = studentName,
                        PhoneNum = phNum,
                        ClassName = className
                    });

                    Console.WriteLine(result == 1 ? "Creating Successfully!! " : "Creating Fail !! ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured . {ex.Message}");
            }
        }

        public void Edit()
        {
            //Enter Id to edit
            Console.Write("Enter Id : ");
            //int editId = Convert.ToInt32(Console.ReadLine());

            if (!int.TryParse(Console.ReadLine(), out int editId))
            {
                Console.WriteLine("Invaild input .");
                return;
            }

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    string query = "select * from StudentTable where DeleteFlag = 0 and StudentId = @StudentId";

                    var item = db.Query<StudentDataModelDapper>(query, new StudentDataModelDapper
                    {
                        StudentId = editId
                    }).FirstOrDefault();

                    if (item is null)
                    {
                        Console.WriteLine("No found Data.");
                        return;
                    }

                    Console.WriteLine($"Student Id => {item.StudentId}");
                    Console.WriteLine($"Student Name => {item.StudentName}");
                    Console.WriteLine($"Student Phone Number => {item.PhoneNum}");
                    Console.WriteLine($"Student Class Name => {item.ClassName}");
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occured . {ex.Message}");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter Id : ");
            if( !int.TryParse(Console.ReadLine(),out int updateId))
            {
                Console.WriteLine("Input not invaild.");
                return ;
            }
            Console.Write("Enter Name : ");
            string updateStudentName = Console.ReadLine();

            if (string.IsNullOrEmpty(updateStudentName))
            {
                Console.WriteLine("Student name can not be null or empty.");
                return;
            }

            Console.Write("Enter Phone Numer : ");
            string updatePhNum = Console.ReadLine();

            if (string.IsNullOrEmpty(updatePhNum))
            {
                Console.WriteLine("Phone Number can not be null or empty.");
                return;
            }

            Console.Write("Enter Class Name : ");
            string updateClassName = Console.ReadLine();

            if (string.IsNullOrEmpty(updateClassName))
            {
                Console.WriteLine("Class Name cannot be null or empty.");
                return;
            }

            string query = @"UPDATE [dbo].[StudentTable]
   SET [StudentName] = @StudentName 
      ,[PhoneNum] = @PhoneNum 
      ,[ClassName] = @ClassName 
      ,[DeleteFlag] = 0
 WHERE studentId = @StudentId";

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    int result = db.Execute(query, new StudentDataModelDapper
                    {
                        StudentName = updateStudentName,
                        PhoneNum = updatePhNum,
                        ClassName = updateClassName ,
                        StudentId = updateId
                    });

                    Console.WriteLine(result == 1 ? "Updating Successfully!! " : "Updating Fail !! ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured . {ex.Message}");
            }

        }

        public void Delete()
        {
            Console.Write("Enter Id : ");//for Delete
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invaild Input!!");
                return;
            }

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM [dbo].[StudentTable]
      WHERE StudentId = @StudentId";

                    var item = db.Execute(query, new StudentDataModelDapper
                    {
                        StudentId = deleteId
                    });

                    Console.WriteLine(item  == 1 ? "Deleting Successfuly." : "No Found .Deleting Fail: ");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured . {ex.Message}");
            }

        }
    }
}
