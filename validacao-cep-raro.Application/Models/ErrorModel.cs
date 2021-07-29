using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace validacao_cep_raro.Application.Models
{
    public class ErrorModel
    {
        public List<string> Erros { get; } = new List<string>();

        public ErrorModel(string erro)
        {
            Erros.Add(erro);
        }

        public ErrorModel(IEnumerable<string> erros)
        {
            Erros.AddRange(erros);
        }

        public ErrorModel(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                Erros.Add(notification.Message);
            }
        }
    }
}
