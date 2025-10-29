using CrudUsuarios.Models;

namespace CrudUsuarios.Services
{
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new();
        private int _nextId = 1;

        public List<Usuario> GetAll() => _usuarios;

        public Usuario? GetById(int id) =>
            _usuarios.FirstOrDefault(u => u.Id == id);

        public Usuario Add(Usuario usuario)
        {
            usuario.Id = _nextId++;
            _usuarios.Add(usuario);
            return usuario;
        }

        public bool Update(int id, Usuario usuarioActualizado)
        {
            var usuario = GetById(id);
            if (usuario == null) return false;

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Email = usuarioActualizado.Email;


            return true;
        }

        public bool Delete(int id)
        {
            var usuario = GetById(id);
            if (usuario == null) return false;

            _usuarios.Remove(usuario);
            return true;
        }
    }
}
