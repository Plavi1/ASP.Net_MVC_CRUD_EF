using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPNETCOREMVC.Models
{
    public class Category
    {
        [Key] //Kljucna rec 
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Range(1,int .MaxValue, ErrorMessage ="Vrednost mora biti veca od nule!")]
        [DisplayName ("Display Order")] //Da bi na stranici View "Create" mogao da imas ispisano odvojeno 
        public int DisplayOrder { get; set; }

    }
}
