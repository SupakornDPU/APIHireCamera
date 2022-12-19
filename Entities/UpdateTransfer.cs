using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Update_Transfer")]
    public partial class UpdateTransfer
    {
        [Key]
        [Column("Update_Id")]
        [StringLength(3)]
        public string UpdateId { get; set; } = null!;
        [Column("Admin_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string AdminId { get; set; } = null!;
        [Column("Transfer_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string TransferId { get; set; } = null!;

        [ForeignKey("AdminId")]
        [InverseProperty("UpdateTransfers")]
        public virtual Admin Admin { get; set; } = null!;
        [ForeignKey("TransferId")]
        [InverseProperty("UpdateTransfers")]
        public virtual Transfer Transfer { get; set; } = null!;
    }
}
