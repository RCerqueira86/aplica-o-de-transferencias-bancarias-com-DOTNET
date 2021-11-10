using System;
using System.Collections.Generic;
using Dio.Banck.Classes;
using Dio.Banck.Enum;

namespace Dio.Banck
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario=ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Despositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                default:
                    throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            System.Console.ReadLine();
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite valor a ser transferido: ");
            double valorTransferencia= double.Parse(Console.ReadLine());
            listaContas[indiceContaOrigem].Transferencia(valorTransferencia,listaContas[indiceContaDestino]);

        }

        private static void Despositar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite valor a ser depositado: ");
            double valorDepositado= double.Parse(Console.ReadLine());
            listaContas[indiceConta].Depositar(valorDepositado);

        }

        private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite valor a ser sacado: ");
            double valorSaque= double.Parse(Console.ReadLine());
            listaContas[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar contas: ");
            if(listaContas.Count == 0) {
                System.Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            } for (int i =0; i<listaContas.Count; i++){
                Conta conta = listaContas[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            } 
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir nova conta");
            System.Console.WriteLine("Digite 1 para conta tipo Pessoa Física e 2 para Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite nome do cliente: ");
            string entradaNome = Console.ReadLine();

            System.Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Dio Banck of América!!!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferencia financeira");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario=Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
       
    }
}
