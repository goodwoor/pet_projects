namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Клиент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клиент()
        {
            Покупка = new HashSet<Покупка>();
        }

        [Key]
        public int Id_клиента { get; set; }

        [Required]
        [StringLength(50)]
        public string ФИО { get; set; }

        [Column("Страна,город")]
        [Required]
        [StringLength(50)]
        public string Страна_город { get; set; }

        public long Номер_телефона { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Покупка> Покупка { get; set; }
    }
}
