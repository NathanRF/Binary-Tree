using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_Binaria___ABB
{
    class ABB
    {
        #region Atributos
        public Nodo Raiz { get; set; }
        #endregion

        #region Construtor
        public ABB()
        {
            this.Raiz = null;
        }
        #endregion

        #region Métodos necessários
        public void Inserir(IDado dado)
        {
            Nodo aux = new Nodo(dado);
            this.Raiz = InserirRecursivo(aux, this.Raiz);
        }

        public IDado Buscar(int chave)
        {
            IDado dado = new Numero(chave); // = new (Tipo da classe) (chave);
            Nodo busca = new Nodo(dado);

            return BuscaRecursiva(busca, this.Raiz).MeuDado;
        }

        public IDado Retirar(int chave)
        {
            IDado dado = new Numero(chave);
            Nodo retirada = new Nodo(dado);
            Nodo aux;
            RetiradaRec(retirada, this.Raiz, out aux); //declaração dentro dos parametros do método

            return aux.MeuDado;
        }

        public override string ToString()
        {
            return EmOrdem(this.Raiz);
        }
        #endregion

        #region Métodos Complementares
        public Nodo RetiradaRec(Nodo quem, Nodo onde, out Nodo saida)
        {
            if(onde == null)
            {
                saida = new Nodo(null);
                return null;
            }
                
            if (quem.MeuDado.CompareTo(onde.MeuDado) < 0)
                onde.Esquerda = RetiradaRec(quem, onde.Esquerda, out saida);
            else if (quem.MeuDado.CompareTo(onde.MeuDado) > 0)
                onde.Direita = RetiradaRec(quem, onde.Direita, out saida);
            else
            {
                saida = new Nodo(onde.MeuDado);
                int grau = onde.Grau();

                switch(grau)
                {
                    case 0:
                        return null;
                        
                    case -1: //filho a esquerda
                        return onde.Esquerda;
                        
                    case 1: //filho a direita
                        return onde.Direita;
                        
                    case 2: //tem dois filhos
                        Nodo antecessor = onde.Antecessor();
                        onde.MeuDado = antecessor.MeuDado;
                        onde.Esquerda = RetiradaRec(antecessor, onde.Esquerda, out saida);

                        break;
                }
            }
            return onde;
        }

        private Nodo InserirRecursivo(Nodo novo, Nodo raiz)
        {
            if (raiz == null) //quando encontra uma raiz nula, vc insere novo
                return novo;

            if (novo.MeuDado.CompareTo(raiz.MeuDado) < 0)
                raiz.Esquerda = InserirRecursivo(novo, raiz.Esquerda);
            else
                raiz.Direita = InserirRecursivo(novo, raiz.Direita);

            return raiz;
        }

        private Nodo BuscaRecursiva(Nodo busca, Nodo raiz)
        {
            if(raiz == null)
                return null;

            if (busca.MeuDado.CompareTo(raiz) == 0)
                return Raiz;
            else if (busca.MeuDado.CompareTo(raiz) < 0)
                return BuscaRecursiva(busca, raiz.Esquerda);
            else
                return BuscaRecursiva(busca, raiz.Direita);
        }

        private string EmOrdem(Nodo raiz)
        {
            if (raiz != null)
            {
                StringBuilder auxImpressao = new StringBuilder();

                auxImpressao.Append(EmOrdem(raiz.Esquerda));
                auxImpressao.Append(raiz.MeuDado.ToString());
                auxImpressao.Append(EmOrdem(raiz.Direita));

                return auxImpressao.ToString();
            }
            else
                return "";
        }

        private string PreOrdem(Nodo raiz)
        {
            //Usado para saber quem é filho de quem 
            //Escreve quem é o pai primeiro (inclusive nas sub raízes)
            //É possível recriar a arvoré igualmente, apenas com essa string criada. Graças a isso, serve como backup se usar como fila

            if (raiz != null)
            {
                StringBuilder auxImpressao = new StringBuilder();
                auxImpressao.Append(raiz.MeuDado.ToString());
                auxImpressao.Append(PreOrdem(raiz.Esquerda));
                auxImpressao.Append(PreOrdem(raiz.Direita));

                return auxImpressao.ToString();
            }
            else
                return "";
        }

        private string PosOrdem(Nodo raiz)
        {
            //Usado para saber quem é filho de quem 
            //Escreve quem é o pai primeiro (inclusive nas sub raízes)
            //É possível recriar a arvoré igualmente, apenas com essa string criada. Graças a isso, serve como backup se usar como pilha

            if (raiz != null)
            {
                StringBuilder auxImpressao = new StringBuilder();

                auxImpressao.Append(PosOrdem(raiz.Direita));
                auxImpressao.Append(PosOrdem(raiz.Esquerda));
                auxImpressao.Append(raiz.MeuDado.ToString());

                return auxImpressao.ToString();
            }
            else
                return "";
        }
        #endregion
    }
}
