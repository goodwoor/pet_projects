namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Антиквариат
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Антиквариат()
        {
            Покупка = new HashSet<Покупка>();
            Экспертиза = new HashSet<Экспертиза>();
        }

        [Key]
        public int Id_антиквариата { get; set; }

        [Required]
        [StringLength(50)]
        public string Наименование { get; set; }

        [Column(TypeName = "money")]
        public decimal Стоимость { get; set; }

        [Required]
        [StringLength(20)]
        public string Состояние { get; set; }

        [Required]
        [StringLength(25)]
        public string Историческая_эпоха { get; set; }

        public bool Наличие_страховки { get; set; }

        [Required]
        [StringLength(50)]
        public string Категория { get; set; }

        public virtual Букинистика Букинистика { get; set; }

        public virtual Оружие Оружие { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Покупка> Покупка { get; set; }

        public virtual Произведение_исскуства Произведение_исскуства { get; set; }

        public virtual Часы Часы { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Экспертиза> Экспертиза { get; set; }

        public virtual Ювелирное_изделие Ювелирное_изделие { get; set; }
    }
}
