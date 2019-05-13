using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Binary_tree
    {
        #region Properties
        public Nodo Root { get; set; }
        #endregion

        public Binary_tree()
        {
            this.Root = null;
        }        

        #region Métodos Básicos
        public void Insert(IDado dado)
        {
            Nodo aux = new Nodo(dado);
            this.Root = InserirRecursivo(aux, this.Root);
        }

        //public IDado Buscar(int chave)
        //{
        //    IDado dado = new Numero(chave); // = new (Tipo da classe) (chave);
        //    Nodo busca = new Nodo(dado);

        //    return BuscaRecursiva(busca, this.Raiz).MeuDado;
        //}

        //public IDado Retirar(int chave)
        //{
        //    IDado dado = new Numero(chave);
        //    Nodo retirada = new Nodo(dado);
        //    Nodo aux;
        //    RetiradaRec(retirada, this.Raiz, out aux); //declaração dentro dos parametros do método

        //    return aux.MeuDado;
        //}

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

        private int quantHomens(int quant, Nodo raiz) //Tentar remover variável quant, pois o valor de quant nas chamadas recursivas deve ser sempre 0, 
                                                      //talvez usar duas variáveis para homens e mulheres para fazer as duas operações no mesmo metodo recursivo
        {
            if (raiz != null)
            {
                if (raiz.MeuDado.SEXO == 'M')
                {
                    quant++;
                }

                quant += (quantHomens(0, raiz.Esquerda));
                quant += (quantHomens(0, raiz.Direita));
            }

            return quant;
        }

        //private string PreOrdem(Nodo raiz)
        //{
        //    //Usado para saber quem é filho de quem 
        //    //Escreve quem é o pai primeiro (inclusive nas sub raízes)
        //    //É possível recriar a arvoré igualmente, apenas com essa string criada. Graças a isso, serve como backup se usar como fila

        //    if (raiz != null)
        //    {
        //        StringBuilder auxImpressao = new StringBuilder();
        //        auxImpressao.Append(raiz.MeuDado.ToString());
        //        auxImpressao.Append(PreOrdem(raiz.Esquerda));
        //        auxImpressao.Append(PreOrdem(raiz.Direita));

        //        return auxImpressao.ToString();
        //    }
        //    else
        //        return "";
        //}

        //private string PosOrdem(Nodo raiz)
        //{
        //    //Usado para saber quem é filho de quem 
        //    //Escreve quem é o pai primeiro (inclusive nas sub raízes)
        //    //É possível recriar a arvoré igualmente, apenas com essa string criada. Graças a isso, serve como backup se usar como pilha

        //    if (raiz != null)
        //    {
        //        StringBuilder auxImpressao = new StringBuilder();

        //        auxImpressao.Append(PosOrdem(raiz.Direita));
        //        auxImpressao.Append(PosOrdem(raiz.Esquerda));
        //        auxImpressao.Append(raiz.MeuDado.ToString());

        //        return auxImpressao.ToString();
        //    }
        //    else
        //        return "";
        //}

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
