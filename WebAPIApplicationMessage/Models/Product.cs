using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplicationMessage.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A chave deve ser maior que zero")]
        public long  IdCategory { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
