using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalElevador.ENum
{
    public enum TipoAcao
    {
        /// <summary>
        /// Elevador sobe um andar 
        /// 
        /// Até o máximo de andares
        /// </summary>
        SOBE,

        /// <summary>
        /// Elevador desce um andar 
        /// 
        /// Até o limite inferior de andares
        /// </summary>
        DESCE,

        /// <summary>
        /// Visita Entra
        /// 
        /// Menor que o maximo - voce
        /// </summary>
        VISITAENTRA,

        /// <summary>
        /// Visita Sai
        /// 
        /// Menor que o visitas - voce
        /// </summary>
        VISITASAI,

        /// <summary>
        /// Voce Entra no elevador
        /// </summary>
        VOCEENTRA,

        /// <summary>
        /// Voce Sai do Elevador
        /// </summary>
        VOCESAI
    }
}
