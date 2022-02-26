using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 character")]
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int UnitId { get; set; }
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 character")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public UnitInformations UnitInformations { get; set; }
        public List<QuotationDetails> QuotationDetails { get; set; }
    }
}
