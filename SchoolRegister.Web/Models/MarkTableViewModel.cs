namespace SchoolRegister.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MarkTableViewModel
    {


        public MarkTableViewModel()
        {
            
        }

        public string[] Categories
        {
            get;
            set;
        }


        public StudentViewModel[] Students
        {
            get;
            set;
        }

        public double[][] Marks
        {
            get;
            set;
        }

        public class StudentViewModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public int Id { get; set; }
        }
    }
}