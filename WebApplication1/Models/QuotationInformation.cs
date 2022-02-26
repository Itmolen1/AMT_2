using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class QuotationInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Currency)]
        public float? TotalAmount { get; set; }
        [DataType(DataType.Currency)]
        public float? VAT { get; set; }
        [DataType(DataType.Currency)]
        public float? GrandTotalAmount { get; set; }
        [MaxLength(4000, ErrorMessage = "Name cannot exceed 4000 character")]
        public string TermCondition { get; set; }
        [MaxLength(4000, ErrorMessage = "Name cannot exceed 4000 character")]
        public string CustomerNote { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public int QuotationNumber  { get; set; }
        public bool ISConverted { get; set; }
        public bool IsNeedSignature { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public bool IsActive { get; set; } = true;

        public UserInformation UserInformation { get; set; }
        public CustomerInformations CustomerInformations { get; set; }
        public List<QuotationDetails> QuotationDetails { get; set; }
    }
}
