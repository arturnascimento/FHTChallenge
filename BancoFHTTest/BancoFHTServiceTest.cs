using BancoFHTRest.Controllers;
using BancoFHTRest.Interfaces;
using BancoFHTRest.Models;
using BancoFHTRest.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;


namespace BancoFHTTest
{
    public class BancoFHTServiceTest
    {

        ////List<ContaModel> _fakeContas;
        ////public BancoFHTServiceTest()
        ////{
        ////    _fakeContas = new List<ContaModel>
        ////    {
        ////        new ContaModel {Id = 1, Conta = 100, Saldo = 1000},
        ////        new ContaModel {Id = 2, Conta = 200, Saldo = 2000},
        ////        new ContaModel {Id = 3, Conta = 300, Saldo = 3000},
        ////    };




        ////}

        ////[Theory]
        ////[InlineData(100)]
        ////[InlineData(200)]
        ////public void Buscar(int conta)
        ////{
        ////    IContaService service = A.Fake<IContaService>();
        ////    ContaService contaService = A.Fake<ContaService>();

        ////    var valid_result = _fakeContas.Find(c => c.Conta == conta);
        ////    bool valid_succeed = (valid_result != null);

        ////    A.CallTo(() => service.GetConta(conta)).Returns(valid_result);

        ////    var controller = new BancoFHTController(contaService);

        ////    var result = controller.Buscar(conta) as ObjectResult;
        ////    var value = result.Value as ActionResult<ContaModel>;

        ////    Assert.Equal(value.Value.Conta.ToString(), valid_result.Conta.ToString());

        ////}

        

            

            




            


        
    }
}
