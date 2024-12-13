namespace SchoolDatabaseMVP.Models
  
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFname { get; set; }
        public string TeacherLname { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
    }
}