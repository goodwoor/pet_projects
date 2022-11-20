namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Оружие
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_антиквариата { get; set; }

        [StringLength(20)]
        public string Вид_оружия { get; set; }

        [StringLength(20)]
        public string Страна_изготовления { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
