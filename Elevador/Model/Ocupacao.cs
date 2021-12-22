using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalElevador.Model
{
    /// <summary>
    /// sem uso .. 
    /// </summary>
    public class Ocupacao
    {
        public String Nome { get; set; }
        public int ID { get; set;}

        public Ocupacao(int nID, string cNome)
        {
            ID = nID;
            Nome = cNome;
        }
    }
}
