using DataAccessLayer.Abstract;
using DataAccessLayer.GenericRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore
{
    public class EfCoreTeacherDal:GenericRepository<Teacher>,ITeacherDal
    {
    }
}
