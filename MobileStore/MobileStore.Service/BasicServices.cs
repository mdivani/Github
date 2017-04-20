using MobileStore.Domain.Entities;
using MobileStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service
{
    public class BasicServices {

        private IUnitOfWork _unit;

        public BasicServices(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Manufacturer> GetOEMS() {
            return _unit.ManufacturerRepository.GetAll();
        }

        public User FindUserByEmail(string email) {
            return _unit.UserRepository.FindByEmail(email);
        }

        public Manufacturer GetManufacturer(int? id = 0) {
            return _unit.ManufacturerRepository.FindById(id);
        }

        public IEnumerable<Phone> GetPopularPhones() {
            return _unit.PhoneRepository.Get(orderBy: q => q.OrderByDescending(x => x.Views)).Take(10);
        }

        public Phone FindPhone(int id) {
            return _unit.PhoneRepository.FindById(id);
        }

        public Phone GetPhone(int id, string IncludeProperties = "") {
            return _unit.PhoneRepository.Get(x => x.ID == id, includeProperties: IncludeProperties).SingleOrDefault();
        }

        public IEnumerable<Comment> GetComments(int articleID) {
            return _unit.CommentRepository.Get(x => x.Article.ID == articleID, orderBy: q => q.OrderBy(x => x.CreateDate));
        }

        public IEnumerable<Phone> GetOEMPhones(int oemID) {
            return _unit.PhoneRepository.Get(x => x.OEMID == oemID && x.IsDeleted == false);
        }

        public IEnumerable<Phone> GetAllPhones() {
            return _unit.PhoneRepository.Get(x => x.IsDeleted == false);
        }

        public IEnumerable<Post> GetPinnedPosts(int Quantity = 3) {
            var posts = _unit.PostRepository.Get(orderBy: x => x.OrderBy(c => c.PinDate)).Take(Quantity);
            if (posts == null) {
                posts = _unit.PostRepository.Get(orderBy: x => x.OrderBy(c => c.CreateDate)).Take(Quantity);
            }
            return posts;
        }

        public IEnumerable<Post> GetAllPosts() {
            return _unit.PostRepository.Get(orderBy: q => q.OrderByDescending(x=> x.CreateDate));
        }

        public void AddView(Phone phone) {
            if (phone != null) {
                int view = phone.Views ?? 0;
                phone.Views = view + 1;
                _unit.PhoneRepository.Update(phone);
                _unit.SaveChanges();
            }
        }

    }
}
