using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("Category_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string CategoryId { get; set; } = null!;
        [Column("Category_Name")]
        [StringLength(20)]
        public string CategoryName { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
