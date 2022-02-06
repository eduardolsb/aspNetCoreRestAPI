using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplicationMessage.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(500, ErrorMessage = "Este campo deve conter entre 1 e 500 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 500 caracteres")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
