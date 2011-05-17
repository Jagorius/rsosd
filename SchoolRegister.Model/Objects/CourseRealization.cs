namespace SchoolRegister.Model.Objects
{
    using System.Collections.Generic;

    using SchoolRegister.Model.Abstract;

    public class CourseRealization : ICourseRealization
    {
        public string ClassCode { get; set; }

        public string CourseName { get; set; }

        public CourseRealization(string classCode, string courseName)
        {
            ClassCode = classCode;
            CourseName = courseName;
        }




        public IEnumerable<MarkCategory> MarkCategories 
        {
            get
            {
                return null;
                //  categories.

            } 
        }


    }
}