using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Pessoa : IDado
    {
        public string NOME { get; private set; }
        public char SEXO { get; private set; }
        public int IDADE { get; private set; }
        public float PESO { get; private set; }

        public Pessoa(string nOME, char sEXO, int iDADE, float pESO)
        {
            NOME = nOME;
            SEXO = sEXO;
            IDADE = iDADE;
            PESO = pESO;
        }

        public override bool Equals(object obj)
        {
            return obj is Pessoa pessoa &&
                   NOME == pessoa.NOME &&
                   SEXO == pessoa.SEXO &&
                   IDADE == pessoa.IDADE &&
                   PESO == pessoa.PESO;
        }

        public int CompareTo(object obj)
        {
            Pessoa aux = (Pessoa) obj;

            return aux.NOME.CompareTo(this.NOME);
        }

        public override string ToString()
        {
            string result;

            result = $"Nome: {NOME}, Sexo: {SEXO}, Idade: {IDADE}, Peso: {PESO}\n";

            return result;
        }
    }
}
