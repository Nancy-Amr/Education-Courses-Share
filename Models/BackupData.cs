using System;
using System.Collections.Generic;

namespace CoursesSharesDB.Models
{
    public class BackupData
    {
        public DateTime BackupDate { get; set; }
        public List<User> Users { get; set; }
        public List<Course> Courses { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Department> Departments { get; set; }
        public List<ResourceCategory> Categories { get; set; }

        public BackupData()
        {
            BackupDate = DateTime.Now;
            Users = new List<User>();
            Courses = new List<Course>();
            Resources = new List<Resource>();
            Departments = new List<Department>();
            Categories = new List<ResourceCategory>();
        }
    }
}
