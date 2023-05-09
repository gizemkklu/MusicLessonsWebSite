using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore
{
    public class EfCoreLessonDal : GenericRepository<Lesson>, ILessonDal
    {
        public List<Lesson> GetListByTeacher()
        {
            using(var c = new Context())
            {
                return c.Lessons.Include(x=>x.teacher).ToList();
            } 
        }
    }
}
