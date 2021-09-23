using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        ExcluirSerie();
                        break;
                    case "4":
                        AtualizarSerie();
                        break;
                    case "5":
                        VisualizarSerie();
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

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                    Console.WriteLine("Id - Nome - Genero");
                    Console.WriteLine("DIO {0} : - {1 } - {2} - {3}", serie.retornaId(), serie.retornaTitulo(), serie.retornaGenero(),excluido ? "*Excluido*" : "");
            }

        }


        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opções acima :");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.proximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }


        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série :");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do inicio da Série :");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descrição da Série :");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
              id: indiceSerie,
              genero: (Genero)entradaGenero,
              titulo: entradaTitulo,
              ano: entradaAno,
              descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine(); ;
            Console.WriteLine("DIO Séries");
            Console.WriteLine("Informe a opção desejada :");
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova série.");
            Console.WriteLine("3 - Excluir série");
            Console.WriteLine("4 - Atualizar série.");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
