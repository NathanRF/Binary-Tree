using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    interface IDado
    {
        string NOME { get; }
        char SEXO { get; }
        int IDADE { get; }
        float PESO { get; }

        string ToString();

        int CompareTo(object obj);
    }
}
