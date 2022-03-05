using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Logo is required.")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 1 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Description Name")]
        [Required(ErrorMessage = "Description is required.")]

        public string Description { get; set; }

        //relationships

        public List<Movie> Movies { get; set; }
    }
}
