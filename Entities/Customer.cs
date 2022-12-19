using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            UpdateCustomers = new HashSet<UpdateCustomer>();
        }

        [Key]
        [Column("Customer_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string CustomerId { get; set; } = null!;
        [Column("Customer_Username")]
        [StringLength(10)]
        public string CustomerUsername { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("Customers")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("CustomerUsername")]
        [InverseProperty("Customers")]
        public virtual CustomerUsername CustomerUsernameNavigation { get; set; } = null!;
        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<UpdateCustomer> UpdateCustomers { get; set; }
    }
}
