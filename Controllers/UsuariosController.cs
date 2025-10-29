using Microsoft.AspNetCore.Mvc;
using CrudUsuarios.Models;
using CrudUsuarios.Services;

namespace CrudUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll() =>
            _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = _service.GetById(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            var nuevo = _service.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuario)
        {
            var actualizado = _service.Update(id, usuario);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _service.Delete(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
