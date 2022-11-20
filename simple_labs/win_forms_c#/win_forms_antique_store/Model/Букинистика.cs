namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Букинистика
    {
        [StringLength(50)]
        public string Автор { get; set; }

        public int Количество_страниц { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_антиквариата { get; set; }

        [StringLength(20)]
        public string Язык { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
