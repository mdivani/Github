using MobileStore.Domain.Entities;
using MobileStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service
{
   public class AdminServices {
        private IUnitOfWork _unit;
        public string error;

        public AdminServices(IUnitOfWork unit) {
            _unit = unit;
        }

        public void AddPhone(Phone phone) {
            _unit.PhoneRepository.Add(phone);
            _unit.SaveChanges();
        }

        public void AddOEM(Manufacturer OEM) {
            _unit.ManufacturerRepository.Add(OEM);
            _unit.SaveChanges();
        }

        public bool AddPost(Post post) {
            _unit.PostRepository.Add(post);
            _unit.SaveChanges();
            return true;
        }

        public void AddComment(Comment comment) {
            _unit.CommentRepository.Add(comment);
            _unit.SaveChanges();
        }

        public void PinPost(int id) {
           var post = _unit.PostRepository.FindById(id);
            if (post != null) {
                post.PinDate = DateTime.Now;
                _unit.SaveChanges();
            }
        }

        public void EditPhone(Phone phone) {
            phone.Manufacturer= _unit.ManufacturerRepository.FindById(phone.Manufacturer.ID);
            _unit.PhoneRepository.Update(phone);
            _unit.SaveChanges();
        }

        public void EditPost(Post post) {
            _unit.PostRepository.Update(post);
            _unit.SaveChanges();
        }

        public void EditComment(int id, string content) {
            var comment = _unit.CommentRepository.FindById(id);
            comment.text = content;
            _unit.SaveChanges();
        }

        public void EditOEM(int id)
        {

        }

        public void DeletePhone(int id)
        {

        }

        public void DeletePost(int id)
        {

        }

        public void DeleteOEM(int id)
        {

        }

        public void DeleteComment(int id)
        {

        }
    }
}
