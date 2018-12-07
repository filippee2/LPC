using Associados.Domain.UsarioRoot;

namespace Associados.Domain.Interaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario AuthUsuario(Usuario usuario);
    }
}