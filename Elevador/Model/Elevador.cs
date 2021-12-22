using FinalElevador.ENum;
using System;
using System.Collections.Generic;

namespace FinalElevador.Model
{
    public class Elevador
    {
        /// <summary>
        /// id do Elevador
        /// </summary>
        public int id { get; }

        /// <summary>
        /// para facilitar a formatação usei estes espaços
        /// 
        /// Criar uma variavel interna para fixar o valor
        /// </summary>
        private String cStatus = "     OK    ";

        /// <summary>
        /// retorna o valor do Status 
        /// 
        /// não tem SET porque o valor é configurado internamente
        /// </summary>
        public String Status { get { return cStatus; } }

        /// <summary>
        /// Só tem o get porque o valor é configurado na criação do objeto
        /// </summary>
        public int MaxOcup { get; }

        /// <summary>
        /// igual ao maxOcup
        /// </summary>
        public int MaxAndar { get; }

        /// <summary>
        /// igual maxOcup
        /// </summary>
        public int AndarInicio { get; }

        /// <summary>
        /// methodo para arquivar quantas pessoas tem no elevador
        /// </summary>
        public int Embarcou { get; set; }

        /// <summary>
        /// methodo que guarda se voce embarcou 
        /// eu poderia ter feito Embarcou e VcEmbarcou apenas GET para que o seu valor fosse apenas atribuido pelo metodo acao
        /// </summary>
        public bool VcEmbarcou { get; set; }

        /// <summary>
        /// variavel de uso interno e lida alguem pede o valor em qual andar o elevador está 
        /// </summary>
        private int nAndarAtual;

        /// <summary>
        /// metodo que retorna o andar atual e configura em qual andar está e nao deixa passar dos limites 
        /// </summary>
        public int AndarAtual
        {
            /// retorno do valor do andar atual 
            get { return nAndarAtual; }
            set
            {
                /// testa se o valor recebido "value" está dentro dos limites
                if (value >= AndarInicio && value <= MaxAndar)
                    nAndarAtual = value;
                else
                {
                    /// em caso de erro fora dos limites.. 
                    /// seta o valor de cStatus.. 
                    cStatus = "ñ " +
                        (value < AndarInicio ? "desce " : "sobe  ") +
                        (value < AndarInicio ? "mín" : "máx");
                };
            }
        }

        /// <summary>
        /// method removido por nao ter usado para simplificar o sistema.
        /// ia colocar o nome dos ocupantes e qual a ordem de entrada.. 
        /// </summary>
        public List<Ocupacao> Ocupacao { get; set; } = new List<Ocupacao>();

        /// <summary>
        /// onde tudo acontece.. 
        /// 
        /// onde as acoes são tomadas.. 
        /// 
        /// se sobe soma andaratual usando o proprio method AndarAtual++
        /// se desce desce andaratual usando o proprio method AndarAtual++
        /// 
        /// no method acima explicado tem as verificações de maximos e minimos .. 
        /// 
        /// VisitaEntra - so pode entrar se tem espaco .. (embarcou < maxocup) => cStatuso = erro
        /// visitaSai - testa se eu estou embarcado ou se tem mais do zero embarcados => cstatuos = erro 
        /// 
        /// Como podemos ver optei por usar um eNum TipoACAO assim a leitura fica mais fácil do que se documentar.. 
        /// 
        /// </summary>
        /// <param name="nAcao"></param>
        /// <returns></returns>
        public String Acao(Int64 nAcao)
        {
            cStatus = "     OK    ";

            // sobe ou desce as vefificações estão na atribuição do method.
            if (nAcao == (int)TipoAcao.SOBE) { AndarAtual++; }
            if (nAcao == (int)TipoAcao.DESCE) { AndarAtual--; }

            
            if (nAcao == (int)TipoAcao.VISITAENTRA)
                // so entra se tem lugar
                if (Embarcou < MaxOcup)
                    Embarcou++;
                else
                    cStatus = "lotado visi";

            if (nAcao == (int)TipoAcao.VISITASAI)
                // so sai se tem alguem dentro.. 
                if ((VcEmbarcou && Embarcou == 1) || Embarcou > 0)
                    Embarcou--;
                else
                    cStatus = "Ñ tem visit";

            if (nAcao == (int)TipoAcao.VOCEENTRA)
                // so embarca se voce não embarcou  e a acao de entrar alguem no elevador for concluido com existo estou chamando o proprio method para executar outra acao
                if ((Embarcou < MaxOcup) && !VcEmbarcou && Acao((int)TipoAcao.VISITAENTRA).Contains("OK"))
                    VcEmbarcou = true;
                else
                    cStatus = ((Embarcou >= MaxOcup) ? " TÁ CHEIO  " : " JA dentro");

            if (nAcao == (int)TipoAcao.VOCESAI)
                // so SAI se voce embarcou e a acao de SAIR for concluido com existo estou chamando o proprio method para executar ACAO VISITASAI
                if (VcEmbarcou && Acao((int)TipoAcao.VISITASAI).Contains("OK"))
                    VcEmbarcou = false;
                else
                    cStatus = "já tá fora ";


            return cStatus;
        }

        /// <summary>
        /// Construtor do objeto que recebe os dados para sua construção.. 
        /// 
        /// Id = numero do elevador
        /// MaxOcup = limite de pessoas no elevador
        /// 
        /// 
        /// </summary>
        /// <param name="Id"> </param>
        /// <param name="MaxOcup"></param>
        /// <param name="MaxAndar"></param>
        public Elevador(int Id, int MaxOcup, int MaxAndar)
        {
            id = Id;
            this.MaxAndar = MaxAndar;
            
            // funcionalidade removida pois teria que fazer um controle adicional em um vetor com os numeros dos andares negativos.. 
            int AndarInicio = 0;
            this.AndarInicio = AndarInicio;

            this.MaxOcup = MaxOcup;
            Embarcou = 0;
            AndarAtual = 0;
            VcEmbarcou = false;
        }

        /// <summary>
        /// Mostra no NOME do Andar.. poderiamos ter algo como 0-Recepção, 1-Langerie, 2-Autos.. 
        /// </summary>
        /// <returns></returns>
        public String NomeAndar()
        {
            return (AndarAtual <= aNomes.Length ? aNomes[AndarAtual] : "Não sei qual  andar"); ;
        }

        /// <summary>
        /// Aqui podemos dar nomes aos andares de um dos elevadores ... depois da inicialização 
        /// Eu poderia ter colocado isso no PREDIO 
        /// eu considerei a possibilidade de um elevador ser para funcionarios e outro para clientes
        /// </summary>
        private String[] aNomes =
            {
                "Térreo  " ,
                "Primeiro",
                "Segundo ",
                "Terceiro",
                "Quarto  " ,
                "Quinto  "
            };

        /// <summary>
        /// methodo que seta os valores dos nomes dos andares.. 
        /// </summary>
        public String[] NomesAndares
        {
            set
            {
                aNomes = value;
            }
        }

    }


}
