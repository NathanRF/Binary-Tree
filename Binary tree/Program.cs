using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Binary_tree arvore = new Binary_tree();

            Pessoa a = new Pessoa("Nathan", 'M', 19, 90);
            Pessoa b = new Pessoa("Nathan R", 'M', 19, 90);
            Pessoa c = new Pessoa("Mathan R", 'M', 19, 90);
            Pessoa d = new Pessoa("Rathan R", 'M', 19, 90);
            Pessoa e = new Pessoa("Zathan R", 'M', 19, 90);


            arvore.Insert(a);
            arvore.Insert(b);
            arvore.Insert(c);
            arvore.Insert(d);
            arvore.Insert(e);

            //string busca = arvore.PesquisaB("Nathan");
            //Console.WriteLine(arvore.ToString());
            //Console.WriteLine(arvore.PesquisaA());

            //if (busca == null)
            //    Console.WriteLine("Não encontrado");
            //else
            //    Console.WriteLine(busca);

            //Console.ReadKey();

            char esc = ' ';

            while(esc != '4')
            {
                Menu();
                esc = Console.ReadKey(true).KeyChar;

                switch (esc)
                {
                    case '1':
                        Console.WriteLine("==== Inserção de pessoas ====");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Sexo: ");
                        char sexo = Console.ReadKey().KeyChar;
                        Console.Write("\nIdade: ");
                        string idade = Console.ReadLine();
                        Console.Write("Peso: ");
                        string peso = Console.ReadLine();

                        Pessoa p = new Pessoa(nome, sexo, int.Parse(idade), float.Parse(peso));
                        arvore.Insert(p);
                        Console.WriteLine($"{nome} inserido com sucesso");
                        Console.ReadKey();

                        break;
                    case '2':

                        Console.Clear();
                        Console.WriteLine("==== Informar a quantidade de homens e a média de idade das mulheres ====");

                        Console.WriteLine(arvore.PesquisaA());

                        Console.ReadKey();

                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("==== Pesquisar a idade e o peso de uma determinada pessoa ====");
                        Console.Write("Insira um nome para a busca: ");
                        string busca = Console.ReadLine();

                        string result = arvore.PesquisaB(busca);

                        if (result == null)
                            Console.WriteLine("Não encontrado");
                        else
                            Console.WriteLine(result);

                        Console.ReadKey();

                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("Pressione qualquer tecla para sair");
                        Console.ReadKey();
                        break;
                    default:
                        Menu();
                        break;
                }

            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Inserir Pessoa");
            Console.WriteLine("2 - Exibir Relatório A");
            Console.WriteLine("3 - Pesquisar a idade e o peso de uma determinada pessoa");
            Console.WriteLine("4 - Sair\n");
            Console.Write("Escolha uma função: ");
        }
    }
}
