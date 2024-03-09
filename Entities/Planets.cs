using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace planets_api.Entities
{
    public class Planets
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100, MinimumLength = 2)]
        public string NomePlaneta { get; set; }


        public int Gravidade { get; set; }
        public int Rotacao { get; set; }
        public string Temperatura { get; set; }
    }
}