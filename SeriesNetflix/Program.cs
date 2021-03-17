using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeriesNetflix.Models;
using SeriesNetflix.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesNetflix
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        public static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaousuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaousuario();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine();

        
    }
        public static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0) //verifica se lista está vazia
            {

                Console.WriteLine("Nenhuma série cadastrada");
            }

            foreach (var serie in lista)//conta os itens da lista e a ê
            {
                var excluido = serie.Excluir();
                Console.WriteLine("#ID {0} : - {1} ", serie.RetonaId(), serie.RetonaTitulo());

            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série ");

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));

            }
            Console.WriteLine("Digite is generos entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                 id: repositorio.ProximoId(),
                 genero: (Genero)entradaGenero,
                 titulo: entradaTitulo,
                 ano: entradaAno,
                 descricao: entradaDescricao);


            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Qual o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1})", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        public static void ExcluirSerie() 
        {
            Console.WriteLine("Digite o Id da série para excluir:");
            int indiceId = int.Parse(Console.ReadLine());
            repositorio.Excluir(indiceId);
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da série para excluir:");
            int indiceId = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornoPorId(indiceId);
            Console.WriteLine(serie);
        }


        public static string ObterOpcaousuario()
        {
            Console.WriteLine();
            Console.WriteLine(" Dio series ao seu dispor");
            Console.WriteLine(" Informe a opçõa desejada");

            Console.WriteLine(" 1- Listar Séries");
            Console.WriteLine(" 2 - Inserir nova série");
            Console.WriteLine(" 3 - Atualizar série");
            Console.WriteLine(" 4 - Excluir série");
            Console.WriteLine(" 5 - Visualizar série");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}