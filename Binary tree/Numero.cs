//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Binary_tree
//{
//    class Numero : IDado
//    {
//        public int num { get; set; }

//        public Numero(int num)
//        {
//            this.num = num;
//        }

//        public override string ToString()
//        {
//            return num + " ";
//        }

//        public int CompareTo(object obj)
//        {
//            Numero aux = (Numero)(obj);

//            if (this.num < aux.num)
//                return -1;
//            else if (this.num > aux.num)
//                return 1;
//            else
//                return 0;
//        }
//    }
//}
