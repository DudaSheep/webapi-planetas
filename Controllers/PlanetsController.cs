using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using planets_api.Entities;
using planets_api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace planets_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly PlanetsContext _context;

        public PlanetsController(PlanetsContext context)
        {
            _context = context;
        }

        // Criar planeta
        [HttpPost]
        public IActionResult RegistrarPlaneta(Planets planet)
        {
            _context.Add(planet);
            _context.SaveChanges();
            // return CreatedAtAction(nameof(ObterPlanetaPorId), new { id = planets.Id }, planet);
            return CreatedAtAction("ObterPlanetasCadastrados", new { id = planet.Id }, planet);
            // return Ok(planet);
        }




        [HttpGet("{id}")]
        public IActionResult ObterPlanetaPorId(int id)
        {
            var planeta = _context.PlanetsDb.Find(id);
            if (planeta == null)
            {
                return NotFound();
            }
            return Ok(planeta);
        }

        [HttpGet]
        public IActionResult ObterPlanetasCadastrados()
        {
            var todosPlanetas = _context.PlanetsDb.ToList();
            return Ok(todosPlanetas);
        }

        [HttpDelete]
        public IActionResult DeletarPlaneta(int id)
        {
            var result = _context.PlanetsDb.Find(id);
            if (result == null)
            {
                return NotFound("Planeta nao encontrado!");
            }
            _context.PlanetsDb.Remove(result);
            _context.SaveChanges();

            return Ok();
        }

    }
}