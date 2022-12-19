using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIWebApp.Entities
{
    [Table("Transfer")]
    public partial class Transfer
    {
        public Transfer()
        {
            Orders = new HashSet<Order>();
            UpdateTransfers = new HashSet<UpdateTransfer>();
        }

        [Key]
        [Column("Transfer_Id")]
        [StringLength(5)]
        [Unicode(false)]
        public string TransferId { get; set; } = null!;
        [Column("CTL_Transfer_Status")]
        public bool CtlTransferStatus { get; set; }
        [Column("Transfer_Slip")]
        public byte[] TransferSlip { get; set; } = null!;

        [InverseProperty("Transfer")]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty("Transfer")]
        public virtual ICollection<UpdateTransfer> UpdateTransfers { get; set; }
    }
}
