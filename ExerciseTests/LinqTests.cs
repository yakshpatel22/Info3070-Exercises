using ExercisesDAL;
using System.Linq;
using System;
using Xunit;
using System.Diagnostics;

namespace ExerciseTests
{
    public class LinqTests
    {
        [Fact]
        public void Test1()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                var selectedStudents = from stu in _db.Students
                                       where stu.Id == 2
                                       select stu;

                Assert.True(selectedStudents.Count() > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }

        }
        [Fact]
        public void Test2()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                var selectedStudents = from stu in _db.Students
                                       where stu.Title == "Ms." || stu.Title == "Mrs."
                                       select stu;

                Assert.True(selectedStudents.Count() > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test3()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                var selectedStudents = from stu in _db.Students
                                       where stu.Division.Name == "Design" 
                                       select stu;

                Assert.True(selectedStudents.Count() > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test4()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                Students selectedStudents = _db.Students.FirstOrDefault(stu => stu.Id == 2);

                Assert.True(selectedStudents.FirstName == "Teachers");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test5()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                var selectedStudents = _db.Students.Where(stu => stu.Title == "Ms." || stu.Title == "Mrs.");

                Assert.True(selectedStudents.Count() > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test6()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                var selectedStudents = _db.Students.Where(stu => stu.Division.Name == "Design");

                Assert.True(selectedStudents.Count() > 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test7()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                Students selectedStudents = _db.Students.FirstOrDefault(stu => stu.Id == 13);

                if (selectedStudents != null)
                {
                    string oldEmail = selectedStudents.Email;
                    string newEmail = oldEmail == "js@someschool.com" ? "PP@someschool.com" : oldEmail;
                    selectedStudents.Email = newEmail;
                    _db.Entry(selectedStudents).CurrentValues.SetValues(selectedStudents);
                }
                Assert.True(_db.SaveChanges() == 1); // 1 indicates the # of rows updated
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test8()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                Students newStudent = new Students
                {
                    FirstName = "Priscilla",
                    LastName = "Marques Peron",
                    PhoneNo = "(555)555-1234",
                    Title = "Mrs.",
                    DivisionId = 10,
                    Email = "js@someschool.com"
                };
                _db.Students.Add(newStudent);
                _db.SaveChanges();
                Assert.True(newStudent.Id > 1); // Should be populated after SaveChanges
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
        [Fact]
        public void Test9()
        {
            try
            {
                SomeSchoolContext _db = new SomeSchoolContext();
                Students selectedStudent = _db.Students.FirstOrDefault(Students => Students.FirstName == "Joe");
                if (selectedStudent != null)
                {
                    _db.Students.Remove(selectedStudent);
                    Assert.True(_db.SaveChanges() == 1); // # of rows deleted
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
    }
}
