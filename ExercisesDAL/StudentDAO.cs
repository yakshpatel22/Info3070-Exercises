using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using ExercisesDAL;
using Microsoft.EntityFrameworkCore;

namespace ExercisesDAL
{
    public class StudentDAO
    {
        readonly IRepository<Students> repository;

        public StudentDAO()
        {
            repository = new SomeSchoolRepository<Students>();
        }
        public Students GetByLastName(string name)
        {
            List<Students> selectedStudents = null;
            try
            {
                selectedStudents = repository.GetByExpression(Students => Students.LastName == name);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedStudents.FirstOrDefault();
        }

        public Students GetById(int id)
        {
            List<Students> selectedStudents = null;
            try
            {
                selectedStudents = repository.GetByExpression(Students => Students.Id == id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedStudents.FirstOrDefault();
        }

        public List<Students> GetAll()
        {
            List<Students> selectedStudents = new List<Students>();
            try
            {
                selectedStudents = repository.GetAll();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedStudents;
        }

        public int Add(Students newStudent)
        {
            try
            {
                newStudent = repository.Add(newStudent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return newStudent.Id;
        }

        public UpdateStatus Update(Students UpdatedStudent)
        {
            UpdateStatus operationStatus = UpdateStatus.Failed;
            try
            {
                operationStatus = repository.Update(UpdatedStudent);

            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return operationStatus;
        }

        public int Delete(int id)
        {
            try
            {
                id = repository.Delete(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return id;
        }

    }
}

