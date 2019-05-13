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

            Pessoa a = new Pessoa("Maximus Decimus Meridius", 'M', 40, 120);
            Pessoa b = new Pessoa("Marcus Aurelius", 'M', 80, 80);
            Pessoa c = new Pessoa("Annia Aurelia Galeria Lucilla", 'F', 30, 75);
            Pessoa d = new Pessoa("Lucius Aurelius Commodus", 'M', 32, 85);

            arvore.Insert(a);
            arvore.Insert(b);
            arvore.Insert(c);
            arvore.Insert(d);
            

            char esc = ' ';

            while(esc != '5')
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
                        Console.WriteLine("Pessoas contidas na arvore:");
                        Console.WriteLine(arvore.ToString());
                        Console.ReadKey();
                        break;
                    case '5':
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
            Console.WriteLine("4 - Exibir pessoas contidas na arvore");
            Console.WriteLine("5 - Sair\n");
            Console.Write("Escolha uma função: ");
        }
    }
}
