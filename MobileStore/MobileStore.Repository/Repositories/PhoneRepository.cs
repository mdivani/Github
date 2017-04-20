using MobileStore.Domain.Entities;
using MobileStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Repository.Repositories
{
   internal class PhoneRepository : Repository<Phone>, IPhoneRepository {
        internal PhoneRepository(ApplicationDbContext context) : base(context) { }

        public IDictionary<int, string> SearchByName(string name, int selected = 10)
        {
            return (from p in _set.Where(x => x.IsDeleted == false)
                    where p.PhoneName.Contains(name)
                    orderby p.PhoneName
                    select (new { value = p.PhoneName, key = p.ID })
                          ).Take(selected).ToDictionary(x => x.key, x => x.value);
        }
    }
}
