using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService:IGenericService<Contact>
    {
        public void TChangeToFalse(int id);
        List<Contact> TGetListByOkundu();
        List<Contact> TGetListByOkunacak();
    }
}
