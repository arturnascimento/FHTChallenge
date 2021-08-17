using BancoFHTRest.Data;
using BancoFHTRest.Interfaces;
using BancoFHTRest.Models;
using System;
using System.Linq;

namespace BancoFHTRest.Services
{
    public class ContaService : IContaService
    {
        BancoFHTContext _context;
        public ContaService(BancoFHTContext context)
        {
            _context = context;
        }
        public bool create(ContaModel contaModel)
        {
            try
            {
                var exists = GetConta(contaModel.Conta);
                if (exists != null) return false;

                _context.ContaModelRest.Add(contaModel);
                _context.SaveChanges();
                return true;
            }

            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool Deposito(int Conta, decimal Valor)
        {
            try
            {
                var exists = GetConta(Conta);
                if (exists == null) return false;
                exists.Saldo += Valor;
                _context.ContaModelRest.Update(exists);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public ContaModel GetConta(int Conta) => _context.ContaModelRest.FirstOrDefault(c=> c.Conta == Conta);
        

        public bool Saque(int Conta, decimal Valor)
        {
            try
            {
                var exists = GetConta(Conta);

                if (exists == null || exists.Saldo < Valor) return false;
                
                exists.Saldo -= Valor;
                _context.ContaModelRest.Update(exists);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(ContaModel contaModel)
        {
            try
            {
                var exists = GetConta(contaModel.Conta);

                if (exists == null) return false;
                exists.Saldo = contaModel.Saldo;
                _context.ContaModelRest.Update(exists);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
