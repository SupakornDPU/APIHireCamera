using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            Customers = new HashSet<Customer>();
            Products = new HashSet<Product>();
            UpdateCustomers = new HashSet<UpdateCustomer>();
            UpdateOrders = new HashSet<UpdateOrder>();
            UpdateProducts = new HashSet<UpdateProduct>();
            UpdateTransfers = new HashSet<UpdateTransfer>();
        }

        [Key]
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Admin_Username")]
        [StringLength(10)]
        public string AdminUsername { get; set; } = null!;
        [Column("Admin_Password")]
        [StringLength(10)]
        public string AdminPassword { get; set; } = null!;
        [Column("Admin_Firstname")]
        [StringLength(20)]
        public string AdminFirstname { get; set; } = null!;
        [Column("Admin_Lastname")]
        [StringLength(20)]
        public string AdminLastname { get; set; } = null!;

        [InverseProperty("Admin")]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<UpdateCustomer> UpdateCustomers { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<UpdateOrder> UpdateOrders { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<UpdateProduct> UpdateProducts { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<UpdateTransfer> UpdateTransfers { get; set; }
    }
}
