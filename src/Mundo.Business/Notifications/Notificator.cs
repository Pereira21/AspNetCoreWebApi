using Mundo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mundo.Business.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notification> ObterNotificacoes()
        {
            return _notifications;
        }

        public bool TemNotificacao()
        {
            return _notifications.Any();
        }
    }
}
