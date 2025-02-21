using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecAPI.Models;

namespace PruebaTecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly PruebaTecContext _context;

        public UsuarioController(PruebaTecContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Usuario? GetByUsurioId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);

        }
        [HttpPost]
        public Usuario CreateUsuario(Usuario usuario)
        {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return usuario;


        }

        [HttpPut("{id}")]
        public Usuario? UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id != id)
                return null;

            var usuarioExistente = _context.Usuarios.Find(id);
            if (usuarioExistente == null)
                return null;

            _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
            _context.SaveChanges();

            return usuarioExistente;
        }

        [HttpGet("all")]
        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();


        }
    }
}
