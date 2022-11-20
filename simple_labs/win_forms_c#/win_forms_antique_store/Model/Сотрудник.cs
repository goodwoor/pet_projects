namespace Антикварный_магазин.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Сотрудник
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сотрудник()
        {
            Покупка = new HashSet<Покупка>();
        }

        [Key]
        public int Id_сотрудника { get; set; }

        [Required]
        [StringLength(50)]
        public string ФИО { get; set; }

        [Column(TypeName = "money")]
        public decimal Зарплата { get; set; }

        public long Номер_телефона { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Покупка> Покупка { get; set; }
    }
}
