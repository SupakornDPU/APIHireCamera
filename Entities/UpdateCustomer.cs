using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Update_Customer")]
    public partial class UpdateCustomer
    {
        [Key]
        [Column("Update_Id")]
        [StringLength(3)]
        public string UpdateId { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Customer_Id")]
        [StringLength(4)]
        [Unicode(false)]
        public string CustomerId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("UpdateCustomers")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("CustomerId")]
        [InverseProperty("UpdateCustomers")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
