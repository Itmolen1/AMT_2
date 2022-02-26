using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class QuotationDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Quotation")]
        public int QuotationId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 character")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public float? UnitPrice { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public float? Total { get; set; }
        [DataType(DataType.Currency)]
        public float? VAT { get; set; }
        [DataType(DataType.Currency)]
        public float? SubTotal { get; set; }

        public QuotationInformation QuotationInformation { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public UnitInformations UnitInformations { get; set; }
    }
}
