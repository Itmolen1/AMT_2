using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ControlAccountInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 character")]
        public string ControlAccountName { get; set; }
        public int Code { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public List<HeadAccountsInformations> HeadAccountsInformations { get; set; }
    }
}
