using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Bank
{
    public class Conta : EntidadeBase
    {
     
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        private bool Exlcuido { get; set; }

        public Conta(int id,TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.Id = id;
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
            this.Exlcuido = false;
        }


        public bool Sacar(double valorSaque,Conta conta)
        {
            //Validação Saldo
            if(conta.Saldo - valorSaque >(conta.Saldo)){
                Console.WriteLine("Saldo Insulficiente!");
                return false;
            }

            conta.Saldo -= valorSaque;
            Console.WriteLine("Saque no valor de {0} da conta {1} realizado com Sucesso" , valorSaque,conta.Nome);
            Console.WriteLine("Saldo Atual da conta de {0} é {1}", conta.Nome , conta.Saldo);
            return true;
        }

        public void Depositar (double depositar,Conta conta)
        {
            conta.Saldo += depositar;
 
            Console.WriteLine("Deposito realizado em nome de {0} no valor de {1}. Saldo total é de : R$",conta.Nome,depositar,conta.Saldo);
            
        }


        public void Transferir(double valorTransaferencia, Conta conta,Conta contaDestino)
        {
            if (conta.Sacar (valorTransaferencia, conta))
            {
                contaDestino.Saldo += valorTransaferencia;
                Console.WriteLine("Transferencia realizada com Sucesso");
                Console.WriteLine("Transferencia realizado em nome de {0} no valor de {1}. Saldo total é de : R${2}", contaDestino.Nome, valorTransaferencia, contaDestino.Saldo);
                Console.WriteLine("Conta Origem {0} - Conta Destino {1}", conta.Nome, contaDestino.RetornaNome());
            }
        }



        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta : " + this.TipoConta + " | ";
            retorno += "Nome : " + this.Nome + " | ";
            retorno += "Saldo : " + this.Saldo + " | ";
            retorno += "Crédito : " + this.Credito;
            retorno += "Excluido :" + this.Exlcuido;
            return retorno;
        }


        public string RetornaNome()
        {
            return this.Nome;
        }

        public double RetornaSaldo()
        {
            return this.Saldo;
        }

        public double RetornaCredito()
        {
            return this.Credito;
        }
        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Exlcuido;
        }
        public void Excluir()
        {
            this.Exlcuido = true;
        }

        public string RetornaTipoConta()
        {
            return this.TipoConta.ToString();
        }
    }



}
