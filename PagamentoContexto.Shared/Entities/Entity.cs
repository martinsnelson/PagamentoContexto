using System;
using Flunt.Notifications;

namespace PagamentoContexto.Shared.Entites
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}