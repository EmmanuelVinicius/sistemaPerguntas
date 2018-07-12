using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgt
{
    class Mensagens
    {
        public bool ErroCatch(bool continua)
        {
            Console.Clear();
            Console.WriteLine("Houve um erro. Por favor, tente novamente.");
            Console.ReadKey();
            return false;
        }

    }
}
