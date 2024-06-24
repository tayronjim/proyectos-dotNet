using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Net8.Data;
using MVC_Net8.Models;

namespace MVC_Net8.Controllers
{
    [Route("lenguajes")]
    public class LenguajesController : Controller
    {
        private readonly ILogger<LenguajesController> _logger;
        private readonly AppDBContext _appDBContext;

        public LenguajesController(ILogger<LenguajesController> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test(){
            return View();
        }

        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> Listado()
        {
            try
            {
                List<Lenguajes> lenguajes = await _appDBContext.lenguajes.ToListAsync();
                return View(lenguajes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el listado de lenguajes.");
                return View("Error");
            }
        }
        [HttpGet]
        [Route("nuevo")]
        public IActionResult Nuevo(){
            return View();
        }


        [HttpPost]
        [Route("nuevo")]
        public async Task<IActionResult> Nuevo(Lenguajes lenguaje)
        {
            await _appDBContext.lenguajes.AddAsync(lenguaje);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Listado));
        }

        [HttpGet]
        [Route("editar")]
        public async Task<IActionResult> Editar(int id)
        {
            Lenguajes lenguaje = await _appDBContext.lenguajes.FirstAsync(l => l.id == id);
            
            return View(lenguaje);
        }

        [HttpPost]
        [Route("editar")]
        public async Task<IActionResult> Editar(Lenguajes lenguaje)
        {
            _appDBContext.lenguajes.Update(lenguaje);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Listado));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Lenguajes lenguaje = await _appDBContext.lenguajes.FirstAsync(l => l.id == id);
            _appDBContext.lenguajes.Remove(lenguaje);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Listado));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}