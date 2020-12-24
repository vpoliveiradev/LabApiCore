using System;
using System.Threading.Tasks;
using VPO.Business.Intefaces;
using VPO.Business.Models;
using VPO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace VPO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}