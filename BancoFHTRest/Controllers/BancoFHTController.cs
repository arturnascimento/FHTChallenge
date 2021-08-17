using BancoFHTRest.Models;
using BancoFHTRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoFHTRest.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BancoFHTController : ControllerBase
    {
        ContaService _service;
        public BancoFHTController(ContaService service)
        {
            _service = service;
          
        }

        /// <summary>
        /// Endpoint responsável pela criação de contas, você deve informar o número da conta e o saldo inicial. Retorna um Json contendo Id, Conta e Saldo.
        /// </summary>
        /// <param name="contaModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/CriarConta")]
        public IActionResult Criar([FromHeader] int Conta, decimal SaldoInicial)
        {
            ContaModel contaModel = new ContaModel();
            contaModel.Conta = Conta;
            contaModel.Saldo = SaldoInicial;

            if (_service.create(contaModel))
            {
                return Ok(_service.GetConta(contaModel.Conta));
            }
            return NotFound("Erro ao criar a conta.");
        }

        /// <summary>
        /// Endpoint responsável por retorna o saldo de uma conta salva no banco de dados. Deve-se informar o número da conta para conseguir o saldo.
        /// </summary>
        /// <param name="Conta"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/SaldoConta{Conta}")]
        public IActionResult Buscar(int Conta) => _service.GetConta(Conta) != null ? Ok($"O Saldo atual é de R${_service.GetConta(Conta).Saldo}") : NotFound("Conta não localizada.");

        /// <summary>
        /// Endpoint responsável pelo saque em conta, você deverá informar o número da conta e o valor do saque. Retorna o saldo atualizado.
        /// </summary>
        /// <param name="Conta"></param>
        /// <param name="Valor"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/Sacar")]
        public IActionResult Sacar([FromHeader]int Conta, decimal Valor)
        {
            if(_service.GetConta(Conta) == null)
            {
                return NotFound("Não foi possível realizar o saque, conta inexistente");
            } else if (_service.Saque(Conta, Valor))
            {
                return Ok($"O Saldo atual é de R${_service.GetConta(Conta).Saldo}");
            }
            return NotFound("Saldo insuficiente para realização do saque.");
        }

        /// <summary>
        /// Endpoint responsável por depositar dinheiro em conta, você deverá informa a conta e o valor para concluir o depósito. Retorna o saldo atualizado.
        /// </summary>
        /// <param name="Conta"></param>
        /// <param name="Valor"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("/Depositar")]
        public IActionResult Depositar([FromHeader]int Conta, decimal Valor)
        {
            if (_service.GetConta(Conta) == null)
            {
                return NotFound("Não foi possível realizar o Depósito, conta inexistente");
            } else if(Valor <= 0)
            {
                return NotFound("Valor de depósito inválido!");
            }
            _service.Deposito(Conta, Valor);
            return Ok($"O Saldo atual é de R${_service.GetConta(Conta).Saldo}");
            
        }


    }
}
