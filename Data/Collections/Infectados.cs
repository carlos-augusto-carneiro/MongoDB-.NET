using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiMongoDB.Data.Collections
{
    public class Infectados
    {
        public Infectados(DateTime dataNascimento, string sexo, double longitude, double latitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizaco = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } = default!;
        public GeoJson2DGeographicCoordinates Localizaco { get; set; } = default!;
    }
}