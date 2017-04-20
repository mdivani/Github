using MobileStore.Domain.Entities;
using MobileStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Repository.Repositories
{
   internal class PostRepository : Repository<Post>, IPostRepository
    {
        internal PostRepository(ApplicationDbContext context) : base(context) { }

    }
}
