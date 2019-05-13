using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Binary_tree
    {
        public Binary_tree()
        {
            this.Root = null;
        }

        #region Properties
        public Nodo Root { get; set; }
        #endregion

        #region Métodos Básicos
        public void Insert(IDado dado)
        {
            Nodo aux = new Nodo(dado);
            this.Root = InserirRecursivo(aux, this.Root);
        }

        public override string ToString()
        {
            return Ordered(this.Root);
        }
        #endregion

        #region Métodos Complementares
        public Nodo RetiradaRec(Nodo quem, Nodo onde, out Nodo saida)
        {
            if (onde == null)
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

                switch (grau)
                {
                    case 0:
                        return null;

                    case -1: //esquerda
                        return onde.Esquerda;

                    case 1: //direita
                        return onde.Direita;

                    case 2: //dois filhos
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
            if (raiz == null)
                return novo;

            if (novo.MeuDado.CompareTo(raiz.MeuDado) < 0)
                raiz.Esquerda = InserirRecursivo(novo, raiz.Esquerda);
            else
                raiz.Direita = InserirRecursivo(novo, raiz.Direita);

            return raiz;
        }

        private Nodo BuscaRecursiva(Nodo busca, Nodo raiz)
        {
            if (raiz == null)
                return null;

            if (busca.MeuDado.CompareTo(raiz.MeuDado) == 0)
                return Root;
            else if (busca.MeuDado.CompareTo(raiz.MeuDado) < 0)
                return BuscaRecursiva(busca, raiz.Esquerda);
            else
                return BuscaRecursiva(busca, raiz.Direita);
        }

        private string Ordered(Nodo raiz)
        {
            if (raiz != null)
            {
                StringBuilder auxImpressao = new StringBuilder();

                auxImpressao.Append(Ordered(raiz.Esquerda));
                auxImpressao.Append(raiz.MeuDado.ToString());
                auxImpressao.Append(Ordered(raiz.Direita));

                return auxImpressao.ToString();
            }
            else
                return "";
        }

        #endregion
       


        #region Questão A - Informar a quantidade de homens e a média de idade das mulheres
        public string Func_A()
        {
            float qtd_Mas = Quantidade_Homens(Root),
                qtd_Fem = Quantidade_Mulheres(Root),
                idade_Fem = Media_Mulheres(Root);

            StringBuilder aux = new StringBuilder();

            aux.AppendLine("Quantidade de Homens: " + qtd_Mas);

            if (qtd_Fem == 0)
                aux.AppendLine("Nenhuma mulher na arvore de pessoas");
            else
                aux.AppendLine("Média de idade das Mulheres: " + (idade_Fem / qtd_Fem) + " anos.");

            
            

            return aux.ToString();
        }

        private int Quantidade_Homens(Nodo raiz)
        {            
            if (raiz != null)
            {
                IDado aux = (raiz.MeuDado);

                if (aux.SEXO == 'M')
                    return 1 + Quantidade_Homens(raiz.Esquerda) + Quantidade_Homens(raiz.Direita);
                else
                    return Quantidade_Homens(raiz.Esquerda) + Quantidade_Homens(raiz.Direita);
            }
            else
                return 0;
        }

        private int Quantidade_Mulheres(Nodo raiz)
        {            
            if (raiz != null)
            {
                IDado aux = (raiz.MeuDado);

                if (aux.SEXO == 'F')
                    return 1 + Quantidade_Mulheres(raiz.Esquerda) + Quantidade_Mulheres(raiz.Direita);
                else
                    return Quantidade_Mulheres(raiz.Esquerda) + Quantidade_Mulheres(raiz.Direita);
            }
            else
                return 0;
        }

        private int Media_Mulheres(Nodo raiz)
        {            
            if (raiz != null)
            {
                IDado aux = (raiz.MeuDado);

                if (aux.SEXO == 'F')
                    return aux.IDADE + Media_Mulheres(raiz.Esquerda) + Media_Mulheres(raiz.Direita);
                else
                    return Media_Mulheres(raiz.Esquerda) + Media_Mulheres(raiz.Direita);
            }
            else
                return 0;
        }

        public string PesquisaA()
        {
            return Func_A();

            //return $"Quantidade de homens: {quantHomens(0, this.Root)}";
        }
        #endregion

        #region Questão B - Pesquisar a idade e o peso de uma determinada pessoa
        private IDado Search(string Nome)
        {
            Nodo busca = new Nodo(new Pessoa(Nome, ' ', 0, 0));

            Nodo aux = BuscaRecursiva(busca, this.Root);
            if (aux == null)
                return null;
            else
                return (aux.MeuDado);
        }

        public string PesquisaB(string Nome)
        {
            IDado aux = Search(Nome);

            if (aux == null)
                return null;
            else
            {
                string a = $"Idade: {aux.IDADE}, Peso: {aux.PESO}";
                return (a);
            }
        }
        #endregion
    }
}
