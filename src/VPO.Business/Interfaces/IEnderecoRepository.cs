using System;
using System.Threading.Tasks;
using VPO.Business.Models;

namespace VPO.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}