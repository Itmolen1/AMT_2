using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 character")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 character")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string UserPassword { get; set; }
        [Required]
        public int GenderId { get; set; }
        public GenderInformations Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;
        
        public List<EmployeeInformations> EmployeeInformations { get; set; }
        public List<DepartmentInformations> DepartmentInformations { get; set; }
        public List<DesignationInformations> DesignationInformations { get; set; }
        public List<TrackUpdateInformations> TrackUpdateInformations { get; set; }
        public List<BloodGroupInformations> BloodGroupInformations { get; set; }
        public List<UnitInformations> UnitInformations { get; set; }
        public List<ProductInfo> ProductInfos { get; set; }
        public List<CustomerInformations> CustomerInformations { get; set; }
        public List<VenderInformations> VenderInformations { get; set; }
        public List<VehicleTypeInformations> VehicleTypeInformations { get; set; }
        public List<VehicleInformation> VehicleInformation { get; set; }
        public List<ControlAccountInformations> ControlAccountInformations { get; set; }
        public List<HeadAccountsInformations> HeadAccountsInformations { get; set; }
        public List<AccountsInformation> AccountsInformation { get; set; }
        public List<TransictionInformations> TransictionInformations { get; set; }
        public List<QuotationInformation> QuotationInformation { get; set; }
        public List<PaymentTypeInformations> PaymentTypeInformations { get; set; }
        public List<ExpenseInformation> ExpenseInformation { get; set; }
        
    }
}
