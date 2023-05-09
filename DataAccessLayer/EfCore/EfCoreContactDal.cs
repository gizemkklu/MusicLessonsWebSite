using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore
{
    public class EfCoreContactDal : GenericRepository<Contact>, IContactDal
    {
        public void ChangeToFalse(int id)
        {
            using (var c = new Context())
            {
                var value = c.Contacts.Find(id);
                value.MessageStatus = false;
                c.Update(value);
                c.SaveChanges();
            }
        }

        public List<Contact> GetListByOkunacak()
        {
            using (var c = new Context())
            {
                return c.Contacts.Where(x => x.MessageStatus == true).ToList();
            }
        }

        public List<Contact> GetListByOkundu()
        {
            using (var c = new Context())
            {
                return c.Contacts.Where(x => x.MessageStatus == false).ToList();
            }
        }
    }
}
