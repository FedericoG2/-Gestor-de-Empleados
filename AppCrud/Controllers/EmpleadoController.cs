using AppCrud.Data;
using AppCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly AppDBContext _appDbContext;

        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        // GET: Empleado
        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var empleados = await _appDbContext.Empleados.ToListAsync();
            return View(empleados);
        }


        // GET: Empleado/Nuevo
        [HttpGet]
        public IActionResult CrearEmpleado()
        {
            return View();
        }

        // POST: Empleado/Nuevo
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _appDbContext.Empleados.AddAsync(empleado);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ObtenerEmpleados));
            }
            return View(empleado);
        }

        // GET: Empleado/Editar/5
        [HttpGet]
        public async Task<IActionResult> EditarEmpleado(int id)
        {
            var empleado = await _appDbContext.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Editar/5
        [HttpPost]
        public async Task<IActionResult> EditarEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _appDbContext.Update(empleado);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ObtenerEmpleados));
            }
            return View(empleado);
        }

        // GET: Empleado/Eliminar/5
        [HttpGet]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            var empleado = await _appDbContext.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }


        // POST: Empleado/Eliminar/5
        [HttpPost, ActionName("EliminarEmpleado")]
        public async Task<IActionResult> ConfirmarEliminarEmpleado(int id)
        {
            var empleado = await _appDbContext.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _appDbContext.Empleados.Remove(empleado);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ObtenerEmpleados));
        }

    }
}
