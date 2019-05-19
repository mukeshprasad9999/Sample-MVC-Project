using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
