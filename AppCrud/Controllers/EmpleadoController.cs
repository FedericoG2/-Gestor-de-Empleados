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


        // GET: Empleado. Se ejecuta al iniciar la aplicacion y obtiene una lista de empleados.
        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var empleados = await _appDbContext.Empleados.ToListAsync();
            return View(empleados);
        }


        // GET: Empleado/CrearEmpleado. Metodo que devuelve el formulario para crear el empleado
        [HttpGet]
        public IActionResult CrearEmpleado()
        {
            return View();
        }

        // POST: Empleado/CrearEmpleado. Metodo que crea el empleado y redirecciona a la lista
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

        // GET: Empleado/EditarEmpleado/id. Metodo que devuelve el formulario para editar el empleado seleccionado
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

        // POST: Empleado/EditarEmpleado/id. Metodo que edita el empleado
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

        // GET: Empleado/EliminarEmpleado/id. Metodo que devuelve el formulario para eliminar el empleado seleccionado
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


        // POST: Empleado/EliminarEmpleado/id. Metodo que elimina el empleado.
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
