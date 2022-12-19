using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Customer_Username")]
    public partial class CustomerUsername
    {
        public CustomerUsername()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("Customer_Username")]
        [StringLength(10)]
        public string CustomerUsername1 { get; set; } = null!;
        [Column("Customer_Password")]
        [StringLength(10)]
        public string CustomerPassword { get; set; } = null!;
        [Column("Customer_Firstname")]
        [StringLength(20)]
        public string CustomerFirstname { get; set; } = null!;
        [Column("Customer_Lastname")]
        [StringLength(20)]
        public string CustomerLastname { get; set; } = null!;
        [Column("Customer_Phone")]
        [StringLength(10)]
        [Unicode(false)]
        public string CustomerPhone { get; set; } = null!;
        [Column("Customer_Address")]
        [StringLength(200)]
        public string CustomerAddress { get; set; } = null!;

        [InverseProperty("CustomerUsernameNavigation")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
