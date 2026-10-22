
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTrack.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Required]
        [Column("medicine_name")]
        public string MedicineName { get; set; } = string.Empty;

        [Column("category")]
        public string? Category { get; set; }

        [Column("batch_number")]
        public string? BatchNumber { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("manufacture_date")]
        public DateTime? ManufactureDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("supplier_name")]
        public string? SupplierName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
