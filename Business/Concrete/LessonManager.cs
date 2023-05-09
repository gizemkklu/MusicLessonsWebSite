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
    public class LessonManager:ILessonService
    {
       ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public List<Lesson> GetListByTeacher()
        {
           return _lessonDal.GetListByTeacher();
        }

        public void TAdd(Lesson entity)
        {
            _lessonDal.Add(entity);
        }

        public void TDelete(Lesson entity)
        {
            _lessonDal.Delete(entity);
        }

        public Lesson TGetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public List<Lesson> TGetFilerwithList(Expression<Func<Lesson, bool>> filter)
        {
            return _lessonDal.GetFilerwithList(filter);
        }

        public List<Lesson> TGetList()
        {
            return _lessonDal.GetList();
        }

        public void TUpdate(Lesson entity)
        {
            _lessonDal.Update(entity);
        }
    }
}
