using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ExpenseDetailsInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public DateTime OnDate { get; set; }
        public string Category { get; set; }
        public int ExpenseRefrenceId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public int GeneralExpenseId { get; set; }
        public string Description { get; set; }   
        public int ExpenseType { get; set; }
        [DataType(DataType.Currency)]
        public float? SubTotal { get; set; }
        [DataType(DataType.Currency)]
        public float? VAT { get; set; }
        [DataType(DataType.Currency)]
        public float? NetTotal { get; set; }    

        public ExpenseInformation ExpenseInformation { get; set; }
        public EmployeeInformations EmployeeInformations { get; set; }
        public VehicleInformation vehicleInformation { get; set; }
        public ProductInfo ProductInfo { get; set; }

    }
}
