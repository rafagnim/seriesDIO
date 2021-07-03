using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoinicial = opcaoFilmesOUSeries();

            while (opcaoinicial.ToUpper() != "S")
            {
                switch(opcaoinicial)
                {
                    case "1":
                        opcaoUsuario(1);
                        break;

                    case "2":
                        opcaoUsuario(2);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoinicial = opcaoFilmesOUSeries();
            }
        }

        private static void Listar(int opcao)
        {
            
            Console.WriteLine("Listar");

            List<Serie> lista = repositorioSerie.Lista();
            List<Filme> lista1 = repositorioFilme.Lista();

            if (opcao == 1) 
            {
                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
            }

            if (opcao == 2) 
            {
                if (lista1.Count == 0)
                {
                    Console.WriteLine("Nenhum filme cadastrado.");
                    return;
                }
                foreach (var filme in lista1)
                {
                    var excluido = filme.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
            }
        }

        private static void Inserir(int opcao)
        {          
            if(opcao == 1) repositorioSerie.Insere(preencherCamposSerie(-1));
            if(opcao == 2) repositorioFilme.Insere(preencherCamposFilme(-1));
        }

        private static void Excluir(int opcao)
        {
            Console.Write("Digite o id da produção: ");
            int indiceProducao = int.Parse(Console.ReadLine());

            if(opcao == 1) repositorioSerie.Exclui(indiceProducao);
            if(opcao == 2) repositorioFilme.Exclui(indiceProducao);
            
        }

        private static void Visualizar(int opcao)
        {

            List<Serie> lista = repositorioSerie.Lista();
            List<Filme> lista1 = repositorioFilme.Lista();

        if (opcao == 1 )
        {
            if (lista.Count != 0)
            {
                Console.Write("Digite o id da produção: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                if (indiceSerie <= lista.Count)
                {
                    var serie = repositorioSerie.RetornaPorID(indiceSerie);
                    Console.WriteLine(serie);
                } else Console.WriteLine("Não há série cadastrada nesta faixa");
            } else Console.WriteLine("Nenhuma série cadastrada.");
            
        }
        if (opcao == 2)
        {
            if (lista1.Count != 0)
            {
                Console.Write("Digite o id da produção: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                if (indiceFilme <= lista1.Count)
                {
                    var filme = repositorioFilme.RetornaPorID(indiceFilme);
                    Console.WriteLine(filme);
                } else Console.WriteLine("Não há filme cadastrado nesta faixa");
 
            } else Console.WriteLine("Nenhum filme cadastrado.");
            
        }

            
        }
        private static void Atualizar(int opcao)
        {

            if (opcao == 1) 
            {
                var lista = repositorioSerie.Lista();
                int indiceSerie = 0;

                if (lista.Count != 0)
                {
                    Console.Write("Digite o id da serie: ");
                    indiceSerie = int.Parse(Console.ReadLine());

                    repositorioSerie.Atualiza(indiceSerie, preencherCamposSerie(indiceSerie));

                } 
                else Console.WriteLine("Nenhuma série cadastrada.");
            }

            if (opcao == 2) 
            {
                var lista = repositorioFilme.Lista();
                int indiceFilme = 0;

                if (lista.Count != 0)
                {
                    Console.Write("Digite o id do filme: ");
                    indiceFilme = int.Parse(Console.ReadLine());

                    repositorioFilme.Atualiza(indiceFilme, preencherCamposFilme(indiceFilme));
                } 
                else Console.WriteLine("Nenhum filme cadastrado.");
            }

        }

        private static Serie preencherCamposSerie(int indiceSerie)
        {
            bool incluiOUatualiza = false;
            if (indiceSerie < 0) incluiOUatualiza = true;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Serie: ");
            string entradaDescrição = Console.ReadLine();

          
                Serie objetoSerie = new Serie(id: incluiOUatualiza ? repositorioSerie.ProximoId() : indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescrição);
                return objetoSerie;
        }

        private static Filme preencherCamposFilme(int indiceFilme)
        {
            bool incluiOUatualiza = false;
            if (indiceFilme < 0) incluiOUatualiza = true;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescrição = Console.ReadLine();

          
                Filme objetoSerie = new Filme(id: incluiOUatualiza ? repositorioFilme.ProximoId() : indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescrição);
                return objetoSerie;
        }

        private static void opcaoUsuario(int opcao)
        {
            string opcaoUsuario = ObterOpcaoUsuario(opcao);

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar(opcao);
                        break;
                    case "2":
                        Inserir(opcao);
                        break;
                    case "3":
                        Atualizar(opcao);
                        break;
                    case "4":
                        Excluir(opcao);
                        break;
                    case "5":
                        Visualizar(opcao);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario(opcao);
            }
        }

        private static string ObterOpcaoInicialUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO SÉRIES e FILMES a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - SÉRIES");
            Console.WriteLine("2 - FILMES");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string opcaoInicialUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");

            return opcaoInicialUsuario;
        }
        private static string ObterOpcaoUsuario(int opcao)
        {
            string producao = "";
            if (opcao == 1)
            {
                producao = "SÉRIE";
            }
            else
            {
                producao = "FILME";
            }
            Console.WriteLine();
            Console.WriteLine("DIO {0} a seu dispor!!!", producao);
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar {0}", producao);
            Console.WriteLine("2 - Inserir {0}", producao);
            Console.WriteLine("3 - Atualizar {0}", producao);
            Console.WriteLine("4 - Excluir {0}", producao);
            Console.WriteLine("5 - Visualizar {0}", producao);
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Retornar ao menu anterior");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");

            return opcaoUsuario;
        }

        private static string opcaoFilmesOUSeries()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes e Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Tratar SÉRIES");
            Console.WriteLine("2 - Tratar FILMES");
            Console.WriteLine("S - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario; 
        }
    }
}