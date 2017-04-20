using MobileStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;
        private IPhoneRepository _phoneRepository;
        private IManufacturerRepository _manufacturerRepository;



        public UnitOfWork()
        {
            if (_context == null) {
               _context = new ApplicationDbContext();
            }
        }


        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public IPhoneRepository PhoneRepository
        {
            get
            {
                return _phoneRepository ?? (_phoneRepository = new PhoneRepository(_context));
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepository ?? (_postRepository = new PostRepository(_context));
            }
        }

        public IManufacturerRepository ManufacturerRepository
        {
            get
            {
                return _manufacturerRepository ?? (_manufacturerRepository = new ManufacturerRepository(_context));
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                return _commentRepository ?? (_commentRepository = new CommentRepository(_context));
            }
        }

        public int SaveChanges() {
            try {
               return _context.SaveChanges();
            }
            catch (DbEntityValidationException e) {
                foreach (var eve in e.EntityValidationErrors) {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors) {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }



        public void Dispose()
        {
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }

    }

}
