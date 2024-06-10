using AppCrud.Data;
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

        // GET: Acceso/Registro Vista formulario registro.
        public IActionResult Registro()
        {
            return View();
        }

        // GET: Acceso/Login Vista formulario inicio de sesion.
        public IActionResult Login()
        {
            return View();
        }


    }
}
