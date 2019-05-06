using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_Binaria___ABB
{
    class Nodo
    {
        public IDado MeuDado { get; set; }
        public Nodo Esquerda { get; set; }
        public Nodo Direita { get; set; }

        public Nodo(IDado dado)
        {
            MeuDado = dado;
            Esquerda = Direita = null;
        }

        public int Grau()
        { 
            //Saber quantos filhos existem
            if (this.Esquerda != null)
                if (this.Direita != null)
                    return 2;
                else
                    return -1; //sinal para saber se é um filho pra esquerda
            else if (this.Direita != null)
                return 1; //sinal para saber se é um filho para a direita
            else
                return 0;
        }


        public Nodo Antecessor()
        {
            Nodo aux = this.Esquerda;

            while (aux.Direita != null)
                aux = aux.Direita;

            return aux;
        }
    }
}
