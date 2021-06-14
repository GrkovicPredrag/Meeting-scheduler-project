using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Data
{
    public class Activity
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime { get; set; }

        [DefaultValue(60)]
        [Column(TypeName = "int")]
        public int Duration { get; set; }

        public string UserUsername { get; set; }

        public virtual User User { get; set; }
    }
}
