using System;
using System.Collections.Generic;
using System.Text;

namespace Series
{
    public class Serie : EntidadeBase
    {
    
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano { get; set; }
        private bool Exlcuido { get; set; }



        // Métodos

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Exlcuido = false;
        }

        public override string ToString()
        {
            string retorne = "";
            retorne += "Genero :" + this.Genero + Environment.NewLine;
            retorne += "Titulo :" + this.Titulo + Environment.NewLine;
            retorne += "Descrição :" + this.Descricao + Environment.NewLine;
            retorne += "Ano de Inicio :" + this.Ano + Environment.NewLine;
            retorne += "Excluido :" + this.Exlcuido;
            return retorne;
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
            return this.Exlcuido;
        }

        public void Excluir()
        {
            this.Exlcuido = true;
        }

        public string retornaGenero()
        {
            return this.Genero.ToString();
        }

    }
}
