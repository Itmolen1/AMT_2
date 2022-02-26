using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AccountsInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "AccountTitle cannot exceed 200 character")]
        public string AccountTitle { get; set; }
        public int Code { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Please select head account")]
        public int HeadAccountId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public HeadAccountsInformations HeadAccountsInformations { get; set; }
        public List<TransictionInformations> TransictionInformations { get; set; }
    }
}
