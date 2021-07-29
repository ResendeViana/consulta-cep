using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace validacao_cep_raro.Domain.Base.Entities
{
    public abstract class ValueObject : Notifiable
    {
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
