using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentCode { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string WorkingArea { get; set; }

        [Required]
        public decimal Commission { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Country { get; set; }

    }
}
