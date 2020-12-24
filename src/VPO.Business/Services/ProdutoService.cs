using System;
using System.Threading.Tasks;
using VPO.Business.Intefaces;
using VPO.Business.Models;
using VPO.Business.Models.Validations;

namespace VPO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUser _user;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IUser user,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _user = user;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            //Pegando dados da Controller utilizando inversão de dependência atendendo aos principios do SOLID
            //Utilizando uma interface para injetar entre uma camada e outra
            //var id = _user.GetUserId();

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}