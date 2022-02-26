using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HeadAccountsInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 character")]
        public string HeadAccountTitle { get; set; }
        public int Code { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select control account")]
        public int ControlAccountId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public ControlAccountInformations ControlAccountInformations { get; set; }
        public List<AccountsInformation> AccountsInformations { get; set; }
    }
}
