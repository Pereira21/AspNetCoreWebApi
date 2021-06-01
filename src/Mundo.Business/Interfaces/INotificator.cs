using Mundo.Business.Notifications;
using System.Collections.Generic;

namespace Mundo.Business.Interfaces
{
    public interface INotificator
    {
        bool TemNotificacao();
        List<Notification> ObterNotificacoes();
        void Handle(Notification notificacao);
    }
}
