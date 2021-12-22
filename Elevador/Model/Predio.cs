using System;
using System.Collections.Generic;

namespace FinalElevador.Model
{
    /// <summary>
    /// definição do predio que tem N elevadores todos com mesma altura e capacidade
    /// na criação do elevador eu poderia ter capacidades diferentes.. 
    /// Deixei documentado no corpo do program.cs
    /// </summary>
    public class Predio
    {
        /// <summary>
        /// Retorna Numero de andares do predio
        /// </summary>
        public int Andares { get; }

        public List<Elevador> ElevadorList { get; } = new List<Elevador>();

        /// <summary>
        /// A criação do elevador optei para receber parametros 
        /// não usei set de method para proporcionar uma validação dos dados - que acabou não sendo usado
        /// Mas eu preveni a alteração de numero de elevadores o qeu poderia ser catastrofico
        /// mas valeu para a demonstração de methods readonly.
        /// 
        /// 
        /// </summary>
        /// <param name="TotAndares"></param>
        /// <param name="NumElevadores"></param>
        /// <param name="OcupacaoMaxCadaElevador"></param>
        public Predio(int TotAndares, int NumElevadores, int OcupacaoMaxCadaElevador)
        {
            if (TotAndares>6)
            {
                throw new Exception("Max Limite de andares no prédio é de 6 andares");
            }

            if (NumElevadores>2)
            {
                throw new Exception("Max Limite de ELEVADORES no prédio é de 2 elevadores");
            }

            Andares = TotAndares;

            ElevadorList = new List<Elevador>();

            for (int i = 0; i < NumElevadores; i++)
            {
                ElevadorList.Add(new Elevador(i, OcupacaoMaxCadaElevador, Andares));
            }
        }

    }
}
