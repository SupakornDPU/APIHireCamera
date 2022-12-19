using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Product_Serial")]
    public partial class ProductSerial
    {
        public ProductSerial()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("Product_Serialnumber")]
        [StringLength(20)]
        [Unicode(false)]
        public string ProductSerialnumber { get; set; } = null!;
        [Column("Product_Name")]
        [StringLength(20)]
        public string ProductName { get; set; } = null!;
        [Column("Product_Price")]
        public int ProductPrice { get; set; }
        [Column("Rental_start_date", TypeName = "date")]
        public DateTime? RentalStartDate { get; set; }
        [Column("Rental_end_date", TypeName = "date")]
        public DateTime? RentalEndDate { get; set; }

        [InverseProperty("ProductSerialnumberNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
