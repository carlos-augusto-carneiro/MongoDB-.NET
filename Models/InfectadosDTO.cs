using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Models
{
    public class InfectadosDTO
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}