namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Покупка
    {
        [Column(TypeName = "date")]
        public DateTime Дата { get; set; }

        public int Id_клиента { get; set; }

        public int Id_сотрудника { get; set; }

        public int Id_антиквариата { get; set; }

        [Key]
        public int Id_покупки { get; set; }

        [Required]
        [StringLength(20)]
        public string Статус { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }

        public virtual Клиент Клиент { get; set; }

        public virtual Сотрудник Сотрудник { get; set; }
    }
}
