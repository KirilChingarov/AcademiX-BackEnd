using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
    public class Thesis
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
      
        public Thesis(int id)
        {
            Id = id;
            Title = string.Empty;
            Description = string.Empty;
        }

        public Thesis(int id, string name, string description = "") : this(id)
        {
            Title = name;
            Description = description;
        }
    }
}
