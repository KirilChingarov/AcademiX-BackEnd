using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AcademiX.Models
{
    public class DegreeSupervisor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Cabinet { get; set; }
        public string WorkingTime { get; set; }
        public bool IsReviewer { get; set; }

        /*
        [Display(Name = "User")]
        public virtual int Id { get; set; }

        [ForeignKey("Id")]
        public virtual User Users { get; set; }
        */
    }
}
