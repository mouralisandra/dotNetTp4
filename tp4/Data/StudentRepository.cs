using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using tp4.Models;

namespace tp4.Data
{
    public interface IStudentRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id); IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        IEnumerable<String> GetCourses();
    }
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly UniversityContext universityContext;
        public StudentRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        public bool Add(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Add(entity);
                universityContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return universityContext.Set<Student>().Where(predicate);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Student Get(int id)
        {
            try
            {

                return universityContext.Set<Student>().Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return universityContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<String> GetCourses()
        {
            return universityContext
                .Student.Select(s => s.course).Distinct().ToList();
        }

        public bool Remove(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Remove(entity);
                universityContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
