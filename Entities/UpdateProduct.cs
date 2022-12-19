using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Update_Product")]
    public partial class UpdateProduct
    {
        [Key]
        [Column("Update_Id")]
        [StringLength(3)]
        public string UpdateId { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Product_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string ProductId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("UpdateProducts")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("UpdateProducts")]
        public virtual Product Product { get; set; } = null!;
    }
}
