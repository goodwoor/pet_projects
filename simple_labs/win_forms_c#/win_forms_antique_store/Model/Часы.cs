namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Часы
    {
        [StringLength(20)]
        public string Вид { get; set; }

        [StringLength(20)]
        public string Основной_материал { get; set; }

        public string Страна_изготовления { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_антиквариата { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
