using System;
using Xunit;
using ExercisesViewModels;
using System.Diagnostics;
using System.Collections.Generic;

namespace ExerciseTests
{
    public class ViewModelTests
    {
        [Fact]
        public void Student_GetByLastNameTest()
        {
            StudentViewModels vm = new StudentViewModels { Lastname = "Pet" };
            vm.GetByLastname();
            Assert.NotNull(vm.Firstname);
        }

        [Fact]
        public void Student_GetByIdTest()
        {
            StudentViewModels vm = new StudentViewModels { Lastname = "Pet" };
            vm.GetByLastname();
            vm.GetById();
            Assert.NotNull(vm.Firstname);
        }

        [Fact]
        public void Student_GetByAllTest()
        {
            StudentViewModels vm = new StudentViewModels();
            List<StudentViewModels> allStudentVms = vm.GetAll();
            Assert.True(allStudentVms.Count > 0);
        }

        [Fact]
        public void Student_AddTest()
        {
            StudentViewModels vm = new StudentViewModels
            {
                Title = "Mrs.",
                Firstname = "Priscilla",
                Lastname = "Peron",
                Email = "pp@abc.com",
                Phoneno = "(555)555-1234",
                DivisionId = 10
            };

            vm.Add();
            Assert.True(vm.Id > 0);
        }

        [Fact]
        public void Student_UpdateTest()
        {
            StudentViewModels vm = new StudentViewModels { Lastname = "Peron" };
            vm.GetByLastname();
            vm.Phoneno = vm.Phoneno == "(555)555-1234" ? "(555)555-4321" : "(555)555-1234";
            int StudentUpdated = vm.Update();
            Assert.True(StudentUpdated > 0);
        }
        [Fact]
        public void Student_DeleteTest()
        {
            StudentViewModels vm = new StudentViewModels { Lastname = "Peron" };
            vm.GetByLastname();
            int StudentDeleted = vm.Delete();
            Assert.True(StudentDeleted == 1);
        }

        [Fact]
        public void Student_ConcurrencyTest()
        {
            StudentViewModels vm1 = new StudentViewModels();
            StudentViewModels vm2 = new StudentViewModels();
            vm1.Lastname = "Peron";
            vm2.Lastname = "Peron";
            vm1.GetByLastname();
            vm2.GetByLastname();
            vm1.Email = (vm1.Email.IndexOf(".ca") > 0) ? "pp@abc.com" : "pp@abc.ca";
            if(vm1.Update() == 1) // update works first time
            {
                vm2.Email = "something@different.com";  // we need something different
                Assert.True(vm2.Update() == -2); // -2 = Stale
            }
            else
                Assert.True(false); // forces a fail

        }

    }
}
