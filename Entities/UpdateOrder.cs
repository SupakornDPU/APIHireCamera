using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Update_Order")]
    public partial class UpdateOrder
    {
        [Key]
        [Column("Update_Id")]
        [StringLength(3)]
        public string UpdateId { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Order_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string OrderId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("UpdateOrders")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("OrderId")]
        [InverseProperty("UpdateOrders")]
        public virtual Order Order { get; set; } = null!;
    }
}
