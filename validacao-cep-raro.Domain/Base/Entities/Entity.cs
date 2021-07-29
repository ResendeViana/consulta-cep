using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace validacao_cep_raro.Domain.Base.Entities
{
    public abstract class Entity : Notifiable
    {
        private Guid _id;
        public virtual Guid Id
        {
            get => _id;
            protected set => _id = value;
        }

        protected Entity() => Id = Guid.NewGuid();
    }
}
