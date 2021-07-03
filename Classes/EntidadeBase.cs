using System;

namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id {get; protected set;}

        public Genero Genero { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int Ano { get; set; }

        private bool Excluido { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
                public void Excluir()
        {
            this.Excluido = true;
        }
    }
}