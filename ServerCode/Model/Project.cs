using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCode.Model
    
{
    public class Project
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Progress")]
        public string Progres { get; set; }

        [Required(ErrorMessage = "Please enter Starting Date")]
        public DateTime S_Date { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "Please enter Deadline")]
        public DateTime Deadline { get; set; }= DateTime.Now;
        
        public ICollection<Taask>? task { get; set; }


    }
}
