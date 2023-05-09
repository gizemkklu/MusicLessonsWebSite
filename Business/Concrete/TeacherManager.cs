using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void TAdd(Teacher entity)
        {
            _teacherDal.Add(entity);
        }

        public void TDelete(Teacher entity)
        {
            _teacherDal.Delete(entity);
        }

        public Teacher TGetById(int id)
        {
            return _teacherDal.GetById(id);
        }

        public List<Teacher> TGetFilerwithList(Expression<Func<Teacher, bool>> filter)
        {
            return _teacherDal.GetFilerwithList(filter);
        }

        public List<Teacher> TGetList()
        {
            return _teacherDal.GetList();
        }

        public void TUpdate(Teacher entity)
        {
            _teacherDal.Update(entity);
        }
    }
}
