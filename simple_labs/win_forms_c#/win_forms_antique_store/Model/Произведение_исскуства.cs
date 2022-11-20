namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Произведение исскуства")]
    public partial class Произведение_исскуства
    {
        [StringLength(50)]
        public string Автор { get; set; }

        [StringLength(20)]
        public string Вид_искусства { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_антиквариата { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
