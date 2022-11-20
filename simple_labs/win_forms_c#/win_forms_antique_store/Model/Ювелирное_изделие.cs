namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ювелирное изделие")]
    public partial class Ювелирное_изделие
    {
        [Key]
        public int Id_антиквариата { get; set; }

        [StringLength(50)]
        public string Материал { get; set; }

        [StringLength(20)]
        public string Вставка { get; set; }

        [Column("Вес(граммы)")]
        
        public double Вес_граммы_ { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
