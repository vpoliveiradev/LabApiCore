using System.Collections.Generic;
using VPO.Business.Notificacoes;

namespace VPO.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}