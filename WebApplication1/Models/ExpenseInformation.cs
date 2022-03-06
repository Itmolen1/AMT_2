using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ExpenseInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int VenderId { get; set; }
        public int EmployeeId { get; set; }
        [DataType(DataType.Currency)]
        public float? TotalAmount { get; set; }
        [DataType(DataType.Currency)]
        public float? VAT { get; set; }
        [DataType(DataType.Currency)]
        public float? GrandTotalAmount { get; set; }
        [MaxLength(4000, ErrorMessage = "Name cannot exceed 4000 character")]
        public string SpecialNote { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int PaymentType { get; set; }
        public int ExpenseNumber { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public VenderInformations VenderInformations { get; set; }
        public List<ExpenseDetailsInformations> ExpenseDetailsInformations { get; set; }
        public EmployeeInformations EmployeeInformations { get; set; }
        public PaymentTypeInformations PaymentTypeInformations { get; set; }
    }
}
