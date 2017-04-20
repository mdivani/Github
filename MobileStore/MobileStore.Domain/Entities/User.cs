using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
   public class User
    {
        [NotMapped]
        private ICollection<Claim> _claims;
        [NotMapped]
        private ICollection<Role> _roles;

        [Key, Required]
        public int UserID { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(256), Required]
        public string PasswordHash { get; set; }
        [MaxLength(256), Required]
        public string SecurityStamp { get; set; }

        public virtual ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }

    }
}
