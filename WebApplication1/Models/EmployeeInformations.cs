using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide name")]
        [MaxLength(200, ErrorMessage = "Allwed only 200 character")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Allwed only 500 character")]
        public string Description { get; set; }
        public int GenderId { get; set; } = 1;
        [MaxLength(500, ErrorMessage = "Allwed only 500 character")]
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public DateTime VisaExpiry { get; set; } = System.DateTime.Now;
        public DateTime PassportExpiry { get; set; } = System.DateTime.Now;
        public DateTime IdCardExpiry { get; set; } = System.DateTime.Now;
        public DateTime DrivingLicienceExpiry { get; set; } = System.DateTime.Now;
        public DateTime DateofBirth { get; set; } = System.DateTime.Now;
        public DateTime HireDate { get; set; } = System.DateTime.Now;
        public string ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select Department")]
        public int DepartmentId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select Blood Group")]
        public int BloodGroupId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select Designation")]
        public int DesignationId { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        [ForeignKey("CreatedBy")]
        public UserInformation UserInformation { get; set; }
        [ForeignKey("DepartmentId")]
        public DepartmentInformations DepartmentInformations { get; set; }
        [ForeignKey("DesignationId")]
        public DesignationInformations DesignationInformations { get; set; }
        [ForeignKey("BloodGroupId")]
        public BloodGroupInformations BloodGroupInformations { get; set; }
        [ForeignKey("GenderId")]
        public GenderInformations GenderInformations { get; set; }

    }
}
