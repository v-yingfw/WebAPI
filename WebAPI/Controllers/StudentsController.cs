using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [RoutePrefix("students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Pranaya" },
            new Student() { Id = 2, Name = "Priyanka" },
            new Student() { Id = 3, Name = "Anurag" },
            new Student() { Id = 4, Name = "Sambit" }
        };
        [HttpGet]
        [Route]
        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }
        [HttpGet]
        [Route("{studentID:int}")]
        public Student GetStudentByID(int studentID)
        {
            Student studentDetails = students.FirstOrDefault(s => s.Id == studentID);
            return studentDetails;
        }
        [HttpGet]
        [Route("{studentName:alpha}")]
        public Student GetStudentDetails(string studentName)
        {
            Student studentDetails = students.FirstOrDefault(s => s.Name == studentName);
            return studentDetails;
        }
        [HttpGet]
        [Route("{studentID}/courses")]
        public IEnumerable<string> GetStudentCourses(int studentID)
        {
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
            return CourseList;
        }
    }
}
