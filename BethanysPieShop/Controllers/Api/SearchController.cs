using BethanysPieShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pies = _pieRepository.AllPies;

            if (pies == null || !pies.Any())
            {
                return NotFound("No pies available.");
            }
            return Ok(pies);
        } 

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var pie = _pieRepository.AllPies.Any(p => p.PieId == id) 
                ? _pieRepository.GetPieById(id) 
                : null;
            if (pie == null)
            {
                return NotFound($"Pie with ID {id} not found.");
            }
            return Ok(pie);
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody]string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }

            return new JsonResult(pies);
        }
    }
}
