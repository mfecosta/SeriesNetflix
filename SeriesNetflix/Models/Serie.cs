using SeriesNetflix.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesNetflix.Models
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}

        public Serie(int id,Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {

            string retorno = "";
            retorno += "Gênero " + Genero + Environment.NewLine;
            retorno += "Título " + Titulo + Environment.NewLine;
            retorno += "Descrição " + Descricao + Environment.NewLine;
            retorno += "Ano de Início " + Ano + Environment.NewLine;
            retorno += "Excluido" + Excluido;

            return retorno;
        }
        public string RetonaTitulo()
        {
            return this.Titulo;
        }

        public int RetonaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
