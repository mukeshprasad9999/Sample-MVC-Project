using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress,ErrorMessage="Please enter valid email address")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
