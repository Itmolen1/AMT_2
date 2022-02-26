using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TransictionInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [DataType(DataType.Currency)]
        public float? Dr { get; set; }
        [DataType(DataType.Currency)]
        public float? Cr { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 character")]
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public DateTime ForDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int TransictionIdentity { get; set; } = System.DateTime.Now.Day+ System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour+System.DateTime.Now.Minute+System.DateTime.Now.Second;

        public UserInformation UserInformation { get; set; }
        public AccountsInformation AccountsInformation { get; set; }
    }
}
