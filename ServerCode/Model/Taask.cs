using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCode.Model
{
    public class Taask
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        

        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
       
        [Required(ErrorMessage = "Please enter Progress")]
        public string Progres { get; set; }

        [Required(ErrorMessage = "Please enter Starting Date")]
        public DateTime S_Date { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "Please enter Deadline")]
        public DateTime Deadline { get; set; }=DateTime.Now;
        //[Required(ErrorMessage = "Please assign pid")]
        public int? ProjectId { get; set; }

        //[Required(ErrorMessage = "Please assign Project")]
        [NotMapped]
        public Project? Project { get; set; }

    }
}
