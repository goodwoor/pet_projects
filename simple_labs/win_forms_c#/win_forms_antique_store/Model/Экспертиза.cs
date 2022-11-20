namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Экспертиза
    {
        [Key]
        public int Номер_договора { get; set; }

        public int Id_антиквариата { get; set; }

        [Required]
        [StringLength(50)]
        public string Оценочная_организация { get; set; }

        [StringLength(20)]
        public string Ценность { get; set; }

        public bool Подтверждение_подлинности { get; set; }

        [Column(TypeName = "money")]
        public decimal Оценочная_стоимость { get; set; }

        public int Примерный_возраст { get; set; }

        [StringLength(50)]
        public string Авторство { get; set; }

        [StringLength(20)]
        public string Место_создания { get; set; }

        public virtual Антиквариат Антиквариат { get; set; }
    }
}
