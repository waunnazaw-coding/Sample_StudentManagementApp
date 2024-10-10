using Microsoft.EntityFrameworkCore;
using Sample_StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_StudentManagementApp
{
    public class UsingEFCore
    {
        //Read 
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Students.Where(student => student.DeleteFlag == false).ToList();

            Console.WriteLine("----- Student Information -----");
            foreach (var student in lst)
            {
               // Console.WriteLine("----- Student Information -----");
                Console.WriteLine($"Student Id => {student.StudentId}");
                Console.WriteLine($"Student Name => {student.StudentName}");
                Console.WriteLine($"Student Phone Number => {student.PhoneNum}");
                Console.WriteLine($"Student's Class Name => {student.ClassName}");
                Console.WriteLine();
            }
            
        }

        //CREATE    
        public void Create(string studentName , string phNum , string className)
        {
            // Creating a new instance of StudentDataModel
            StudentDataModel createStudents = new StudentDataModel
            {
                StudentName = studentName,
                PhoneNum = phNum,
                ClassName = className
            };

            // Creating a new instance of AppDbContext
            AppDbContext db = new AppDbContext();

            // Adding the new student to the Students DbSet
            db.Students.Add(createStudents);

            // Saving changes to the database
            var result = db.SaveChanges();

            // Outputting the result of the operation
            Console.WriteLine(result == 1 ? "Create Successfully!" : "Create Fail!");
        }

        //Edit
        public void Edit(int studentId)
        {
            AppDbContext db = new AppDbContext();
            var student = db.Students.FirstOrDefault(student => student.StudentId == studentId);
            if (student is null)
            {
                Console.WriteLine("This Student does not extists!");
            }
            else
            {
                Console.WriteLine($"Student Id => {student.StudentId}");
                Console.WriteLine($"Student Name => {student.StudentName}");
                Console.WriteLine($"Student Phone Number => {student.PhoneNum}");
                Console.WriteLine($"Student's Class Name => {student.ClassName}");
                Console.WriteLine();
            }
        }

        //Update
        public void Update(int studentId , string studentName , string phNum , string className)
        {
            AppDbContext db = new AppDbContext();
            var student = db.Students
                            .AsNoTracking()
                            .FirstOrDefault(student => student.StudentId == studentId);
            if (student is null)
            {
                Console.WriteLine("This Student does not extists!");
                return;
            }

            if (!string.IsNullOrEmpty(studentName) )
            {
                student.StudentName = studentName;
            }

            if (!string.IsNullOrEmpty(phNum))
            {
                student.PhoneNum = phNum;
            }

            if (!string.IsNullOrEmpty(className))
            {
                student.ClassName = className;
            }
            db.Entry(student).State = EntityState.Modified;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating Successfully! " : "Updating Fail!");
            
        }

        // DELETE
        public void Delete(int studentId)
        {
            AppDbContext db = new AppDbContext();
            var student = db.Students.FirstOrDefault(student => student.StudentId == studentId);
            if (student is null)
            {
                Console.WriteLine("This Student does not extists!");
                return;
            }

            db.Students .Remove(student);
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting Successfully! " : "Deleting Fail! ");
        }

        public void MenuList()
        {
            Console.WriteLine("----- MENU LISTS -----");
            Console.WriteLine("1 . READ ALL STUDENTS ! ");
            Console.WriteLine("2 . CREATE OR ADD NEW STUDENT ! ");
            Console.WriteLine("3 . EDIT STUDENT ! ");
            Console.WriteLine("4 . UPDATE STUDENT ! ");
            Console.WriteLine("5 . DELETE STUDENT  ! ");
            Console.WriteLine("6 . TO EXIST ! ");
            Console.WriteLine("Choose Funtion (1 - 6) =>  ");
        }


    }
}
