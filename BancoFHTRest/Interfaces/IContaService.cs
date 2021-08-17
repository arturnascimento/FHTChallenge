using BancoFHTRest.Models;

namespace BancoFHTRest.Interfaces
{
    public interface IContaService
    {
        //método booleano para criação de conta
        bool create(ContaModel contaModel);
        //método booleano para sacar valores
        bool Saque(int Conta, decimal Valor);
        //método booleano para depositar valores
        bool Deposito(int Conta, decimal Valor);
        //método para buscar conta desejada
        ContaModel GetConta(int Conta);

        //método booleano para editar conta
        bool Update(ContaModel contaModel);
    }
}
