using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            UpdateProducts = new HashSet<UpdateProduct>();
        }

        [Key]
        [Column("Product_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string ProductId { get; set; } = null!;
        [Column("Product_Serialnumber")]
        [StringLength(20)]
        [Unicode(false)]
        public string ProductSerialnumber { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Category_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string CategoryId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("Products")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey("ProductSerialnumber")]
        [InverseProperty("Products")]
        public virtual ProductSerial ProductSerialnumberNavigation { get; set; } = null!;
        [InverseProperty("Product")]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<UpdateProduct> UpdateProducts { get; set; }
    }
}
