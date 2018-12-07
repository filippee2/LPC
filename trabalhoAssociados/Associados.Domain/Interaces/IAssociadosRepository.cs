using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.Domain.AssociadoRoot;

namespace Associados.Domain.Interaces
{
    public interface IAssociadosRepository : IRepositoryBase<Associado>
    {
        Task<List<AssociadoDTO>> GetAllDTO();
        Task<AssociadoDTO> GetByIdDTO(long id);
    }
}