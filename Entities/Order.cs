using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            UpdateOrders = new HashSet<UpdateOrder>();
        }

        [Key]
        [Column("Order_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string OrderId { get; set; } = null!;
        [Column("Product_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string ProductId { get; set; } = null!;
        [Column("Transfer_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string TransferId { get; set; } = null!;
        [Column("Customer_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string CustomerId { get; set; } = null!;

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("Orders")]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey("TransferId")]
        [InverseProperty("Orders")]
        public virtual Transfer Transfer { get; set; } = null!;
        [InverseProperty("Order")]
        public virtual ICollection<UpdateOrder> UpdateOrders { get; set; }
    }
}
