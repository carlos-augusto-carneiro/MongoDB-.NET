using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDB.Data.Collections;
using ApiMongoDB.Models;
using DnsClient.Protocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ApiMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadosController : ControllerBase
    {
        Data.MongoDb _mongoDb;  

        IMongoCollection<Infectados> _infectadosColletions;
        public InfectadosController(Data.MongoDb mongoDb)
        {
            _mongoDb = mongoDb;
            _infectadosColletions = _mongoDb.DB.GetCollection<Infectados>(typeof(Infectados).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadosDTO dto)
        {
            var infectado = new Infectados(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosColletions.InsertOne(infectado);

            return StatusCode(201, "infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfecatado()
        {
            var infectado = _infectadosColletions.Find(Builders<Infectados>.Filter.Empty).ToList();

            return Ok(infectado);
        }
    }
}