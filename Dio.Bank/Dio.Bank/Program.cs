using System;

namespace Dio.Bank
{
    class Program
    {
        static ContaRepositorio repositorio = new ContaRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        ExcluirConta();
                        break;
                    case "4":
                        AtualizarConta();
                        break;
                    case "5":
                        VisualizarConta();
                        break;
                    case "6":
                        Transferir();
                        break;
                    case "7":
                        Depositar();
                        break;
                    case "8":
                        Sacar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                        //default:
                        //throw ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar Contas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (var conta in lista)
            {
                var excluido = conta.RetornaExcluido();
                Console.WriteLine("Id - Nome - Tipo de Conta - Saldo - Crédito - Situação");
                Console.WriteLine("DIO BANK {0} : - {1 } - {2} - {3} - {4} - {5}", conta.RetornaId(), conta.RetornaNome(), conta.RetornaTipoConta(),conta.RetornaSaldo(),conta.RetornaCredito(), excluido ? "*Excluido*" : "Regular");
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");


            foreach (int i in Enum.GetValues(typeof(TipoConta)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(TipoConta), i));
            }

            Console.WriteLine("Digite o Tipo da Conta entre as opções acima :");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Correntista");
            string entradaNome= Console.ReadLine();

            Console.WriteLine("Digite o Saldo do Correntista");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito do Correntista");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                id: repositorio.ProximoId(),
                tipoConta: (TipoConta)entradaTipoConta,
                nome: entradaNome,
                saldo: entradaSaldo,
                credito: entradaCredito);

            repositorio.Insere(novaConta);

        }

        private static void ExcluirConta()
        {
            Console.WriteLine("Digite o Id da Conta");
            int indiceConta = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceConta);
        }

        private static void AtualizarConta()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceConta = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(TipoConta)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(TipoConta), i));
            }

            Console.WriteLine("Digite o Tipo da Conta entre as opções acima :");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Correntista");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo do Correntista");
            int entradaSaldo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito do Correntista");
            int entradaCredito = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                id: repositorio.ProximoId(),
                tipoConta: (TipoConta)entradaTipoConta,
                nome: entradaNome,
                saldo: entradaSaldo,
                credito: entradaCredito);

            repositorio.Atualiza(indiceConta, novaConta);


        }

        private static void VisualizarConta()
        {
            Console.WriteLine("Digite o Id da Conta");
            int indiceConta = int.Parse(Console.ReadLine());

            var conta = repositorio.RetornaPorId(indiceConta);

            Console.WriteLine(conta);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Id da Conta");
            int indiceConta = int.Parse(Console.ReadLine());
            var conta = repositorio.RetornaPorId(indiceConta);

            Console.WriteLine("Digite o Id da Conta Destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            var contaDestino = repositorio.RetornaPorId(indiceContaDestino);

            Console.WriteLine("Digite o valor a ser transferido");
            int entradaTransferencia = int.Parse(Console.ReadLine());

            conta.Transferir(entradaTransferencia, conta, contaDestino);


        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o Id da Conta");
            int indiceConta = int.Parse(Console.ReadLine());
            var conta = repositorio.RetornaPorId(indiceConta);

            Console.WriteLine("Digite o valor a ser depositado");
            int entradaDeposito = int.Parse(Console.ReadLine());

            conta.Depositar(entradaDeposito, conta);


        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Id da Conta");
            int indiceConta = int.Parse(Console.ReadLine());
            var conta = repositorio.RetornaPorId(indiceConta);

            Console.WriteLine("Digite o valor a ser sacado");
            int entradaSaque = int.Parse(Console.ReadLine());

            conta.Sacar(entradaSaque, conta);


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu Dispor");
            Console.WriteLine("Informe a opção desejada :");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Conta");
            Console.WriteLine("3 - Excluir ");
            Console.WriteLine("4 - Atualizar Conta ");
            Console.WriteLine("5 - Visualizar Conta ");
            Console.WriteLine("6 - Tranferir ");
            Console.WriteLine("7 - Depositar ");
            Console.WriteLine("8 - Sacar ");
            Console.WriteLine("X - Sair ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;


        }


    }
}
