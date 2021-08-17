using System.ComponentModel.DataAnnotations;

namespace BancoFHTRest.Models
{
    public class ContaModel
    {
        [Key]
        public int Id { get; set; }
        public int Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
