using AppCrud.Data;
using AppCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AppCrud.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _context;

        public AccesoController(AppDBContext context)
        {
            _context = context;
        }


        // GET: Acceso/Login Vista formulario inicio de sesion.
        public IActionResult Login()
        {
            return View();
        }

        // POST: Acceso/Registro Metodo que crea un usuario.
        [HttpPost]
        [AllowAnonymous] 
        
        public IActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("ObtenerEmpleados", "Empleado"); 
            }
            return View(usuario);
        }

        // POST: Acceso/Login
        [HttpPost]
        
        public IActionResult Login(string nombreUsuario, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Password == password);
            if (usuario != null)
            {
                // Lógica para manejar el login exitoso (por ejemplo, establecer cookies de autenticación)
                return RedirectToAction("ObtenerEmpleados", "Empleado");
            }
            ViewBag.Error = "Nombre de usuario o contraseña incorrectos";
            return View();
        }



    }
}
