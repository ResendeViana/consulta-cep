using Flunt.Validations;
using validacao_cep_raro.Domain.Base.Entities;

namespace validacao_cep_raro.Domain.ValueObjects
{
    public class Cep : ValueObject
    {
        public Cep(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Numero, nameof(Cep.Numero), "CPF não pode ser nulo ou branco")
                .HasLen(Numero, 8, nameof(Cep.Numero), "CPF deve conter 8 posições")
                .IsDigit(Numero, nameof(Cep.Numero), "CPF deve conter apenas números"));
        }

        public string Numero { get; private set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}
