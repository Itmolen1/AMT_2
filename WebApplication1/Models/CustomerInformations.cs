using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CustomerInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 character")]
        public string CompanyName { get; set; }
        public string TRNNumber { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNumber { get; set; }
        public string LandLine { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public string Country { get; set; } 
        [MaxLength(300, ErrorMessage = "Name cannot exceed 300 character")]
        public string Address { get; set; }
        [MaxLength(2000, ErrorMessage = "Name cannot exceed 2000 character")]
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public List<QuotationInformation> QuotationInformation { get; set; }
    }
}
