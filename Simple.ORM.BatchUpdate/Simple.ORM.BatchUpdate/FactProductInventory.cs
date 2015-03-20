namespace Simple.ORM.BatchUpdate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FactProductInventory")]
    public partial class FactProductInventory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime MovementDate { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitCost { get; set; }

        public int UnitsIn { get; set; }

        public int UnitsOut { get; set; }

        public int UnitsBalance { get; set; }
    }
}