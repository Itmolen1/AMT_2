using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class VehicleInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 character")]
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public DateTime MulkiyaExpiry { get; set; } = System.DateTime.Now;
        public DateTime InsuranceExpiry { get; set; } = System.DateTime.Now;
        public string TCNumber { get; set; } 
        public string Brand { get; set; }
        [MaxLength(1000, ErrorMessage = "Name cannot exceed 1000 character")]
        public string RegisterdRegion { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please select vehicle type")]
        public int VehicleTypeId { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public VehicleTypeInformations VehicleTypeInformations { get; set; }
        
    }
}
