namespace Simple.RadGridPaging.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Region")]
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}