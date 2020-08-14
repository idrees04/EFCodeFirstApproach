using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace EFCodeFirstApproach.Models
{
    public class StudentContextcs:DbContext
    {
        // this class will convert into table in database(of student.cs property will convert into table)
        // we will add (namespase 9using System.Data.Entity;)
        // DBContext class will exchange data in between database and student model class
        public DbSet<Student> students { get; set;}
        //DBSet will store data of Model class Student.cs 
        //table name will be students

    }
}