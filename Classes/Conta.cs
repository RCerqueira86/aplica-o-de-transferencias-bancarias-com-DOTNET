using System;
using Dio.Banck.Enum;

namespace Dio.Banck.Classes
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
        public Conta (TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
         public bool Sacar (double valorSaque){
            //Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito*-1)){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            
            this.Saldo-=valorSaque;  //this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}",this.Nome, this.Saldo);
            
            return true;       

        }
        public void Depositar (double valorDepositado){
            this.Saldo+= valorDepositado;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}",this.Nome, this.Saldo);
        }
        public void Transferencia (double valorTransferencia, Conta contadestino){
            if(this.Sacar(valorTransferencia)){
                contadestino.Depositar(valorTransferencia);
                System.Console.WriteLine("Foi transferido R${0} para {1}", valorTransferencia, contadestino);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome cadastrado: " + this.Nome + " | ";
            retorno += "Saldo é de R$" + this.Saldo + " | ";
            retorno += "Crédito é de R$" + this.Credito + " | ";
            return retorno;
        }
    }
}