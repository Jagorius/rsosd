using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolRegister.Web.Controllers
{
    using SchoolRegister.Model.Abstract;

    public class CourseRealizationController : Controller
    {
        private ICourseRealization courseRealization;

        public CourseRealizationController(ICourseRealization courseRealization)
        {
            this.courseRealization = courseRealization;
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Menu()
        {
            return null;
      
        }



        public ActionResult Header()
        {
            return this.View(courseRealization);

        }


        public ActionResult Marks()
        {

            return null;
            /*


            var categories = from markCategory in CreateQuery<MarkCategorySchema>()
            where markCategory.CourseRealizationId == CourseRealizationId
            select markCategory;
             
            // categories = this.MarkCategories;




            var marksTable = new MarksTableViewModel();



             var students = from student in CreateQuery<StudentSchema>()
            where student.CourseRealizationId == CourseRealizationId
            select student;

            // students = this.Students;


            string [] catArray = categories.Select((cat, i) => cat.Name).ToArray();


            StudentViewModel[] studArray = students.Select((stud, i) => 
                new StudentViewModel{Name = stud.Name, Surname = stud.SurName}).ToArray();

            studArray.Sort((a, b) => string.Compare(a.Surname, b.Surname));



            int c = 0;
            foreach (var category in categories)
            {
                var marks = from mark in CreateQuery<Mark>()
                            where mark.Cathegory == markCategory.Category
                            select mark;

                    
                // marks = category.Marks;
                   




                foreach (var mark in marks)
                {

                    StudentSchema student = (from stud in CreateQuery<StudentSchema>()
                                       where stud.Id == mark.StudentId
                                       select stud).Single();

                    PersonSchema person = (from pers in CreateQuery<PersonSchema>()
                                     where pers.Id == student.PersonId
                                     select pers).Single();

                    // mark.Student.Person
                        
                    int s = 0;
                    foreach (var stud in studArray)
                    {
                        if(stud.Id == student.Id)
                        {
                            marksTable.MarkTable[s][c] = mark.markvalue;

                        }
                        s++;
                    }

                }

                c++;

                   

                    

            }
                


            */
        }


    }
}
