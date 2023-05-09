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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void TChangeToFalse(int id)
        {
            _contactDal.ChangeToFalse(id);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact TGetById(int id)
        {
           return _contactDal.GetById(id);
        }

        public List<Contact> TGetFilerwithList(Expression<Func<Contact, bool>> filter)
        {
            return _contactDal.GetFilerwithList(filter);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public List<Contact> TGetListByOkunacak()
        {
            return _contactDal.GetListByOkunacak();
        }

        public List<Contact> TGetListByOkundu()
        {
            return _contactDal.GetListByOkundu();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
