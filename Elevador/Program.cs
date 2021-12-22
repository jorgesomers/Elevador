using System;
using FinalElevador.Model;


namespace FinalElevador
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Teremos 2 erros para demonstração antes de iniciar o programa:");

            try
            {
                /// Criação do predio e seus elevadores com erro 
                Predio EdComErro = new Predio(8, 2, 40);
            }
            /// interceptacao do erro 
            catch (Exception erro)
            {
                Console.WriteLine("Tecle <ENTER> para continuar - " + erro.Message);
                Console.ReadLine();
            }

            try
            {
                /// Criação do predio e seus elevadores com erro 
                Predio EdComErro2 = new Predio(4, 5, 40);
            }
            /// interceptacao do erro 
            catch (Exception erro)
            {

                Console.WriteLine("Tecle <ENTER> para continuar - " + erro.Message);
                Console.ReadLine();
            }


            /// Criação do predio e seus elevadores
            Predio EdClaraNunes = new Predio(6, 2, 4);

            // alteração dos nomes dos andares.. 
            EdClaraNunes.ElevadorList[0].NomesAndares = new string[] {
                "Recepcao" ,
                "Langerie",
                "Masculin",
                "Carros  ",
                "Escritor" ,
                "Helicopt"
            };

            /// Deixei documentado aqui para uma possivel necessidade de alteração do sistema 
            /// para poder alterar o numero de andares de UM dos elevadores do predio
            /// 
            /// EdClaraNunes.ElevadorList[1].MaxAndar = 6;

            String nElevador = "", Direcao = "";
            do
            {
                // criação ta tela vazia.. 
                String cResultado = (new Imagem()).cOcupacao;

                // limpeza de tela 
                Console.Clear();
                
                // so uma mensagem.. 
                Console.WriteLine(@"O predio tem " + EdClaraNunes.ElevadorList.Count.ToString() + " elevadores e tem " + EdClaraNunes.Andares + " andares ");
                
                /// optei por replace por ser mais rapido 
                /// deveria ter criado uma classe com a tela.. 
                /// Com a Clase ela faria a concatenação dos dados e retornar uma string.. 

                foreach (Elevador itmElevador in EdClaraNunes.ElevadorList)
                {
                    cResultado = cResultado.Replace("TA" + itmElevador.id.ToString().Trim(), itmElevador.MaxAndar.ToString("D3"));
                    cResultado = cResultado.Replace("MX" + itmElevador.id.ToString().Trim(), itmElevador.MaxOcup.ToString("D3"));
                    cResultado = cResultado.Replace("OA" + itmElevador.id.ToString().Trim(), itmElevador.Embarcou.ToString("D3"));
                    cResultado = cResultado.Replace("AA" + itmElevador.id.ToString().Trim(), itmElevador.AndarAtual.ToString("D3"));
                    cResultado = cResultado.Replace("NA" + itmElevador.id.ToString().Trim(), itmElevador.NomeAndar());
                    cResultado = cResultado.Replace("VCD" + itmElevador.id.ToString().Trim(), (itmElevador.VcEmbarcou ? "SIM " : " NAO"));
                    cResultado = cResultado.Replace("STATUSATUA" + itmElevador.id.ToString().Trim(), itmElevador.Status);
                }

                /// se o numero de elevadores é menor do que a tela eu zero os dados do elevador inexistente
                /// foi muito util durante o desenvolvimento para limpar a tela.. 
                /// 
                if (EdClaraNunes.ElevadorList.Count <= 2)
                {
                    for (int i = 1; i <= EdClaraNunes.ElevadorList.Count; i++)
                    {
                        cResultado = cResultado.Replace("TA" + i.ToString().Trim(), "   ");
                        cResultado = cResultado.Replace("MX" + i.ToString().Trim(), "   ");
                        cResultado = cResultado.Replace("OA" + i.ToString().Trim(), "   ");
                        cResultado = cResultado.Replace("AA" + i.ToString().Trim(), "   ");
                        cResultado = cResultado.Replace("VCD" + i.ToString().Trim(), "    ");
                        cResultado = cResultado.Replace("STATUSATUA" + i.ToString().Trim(), "           ");
                    }
                }
                Console.WriteLine(cResultado);

                /// zera variavel para aguardar.. novo elevador
                /// 
                nElevador = "";
                Console.WriteLine("e(X)it ou #Elevador");
                do
                {
                    nElevador = Console.ReadLine().ToUpper();
                } while (!(nElevador.ToString().Length > 0 && "X0123456789".Contains(nElevador) && Convert.ToInt16(nElevador) < EdClaraNunes.ElevadorList.Count && Convert.ToInt16(nElevador) >= 0) || nElevador == "X");

                /// se teclou X para o programa
                /// deixei o resquicio do teste se eu teclasse nada apenas enter ele tambem cairia fora.. 
                if (nElevador == "X" || nElevador == "")
                {
                    break;
                }

                Console.WriteLine(@"e(X)it ou 0=Sobe 1=Desce 2=Visita entra, 3=Visita sai, 4=Voce entra, 5=Voce sai");
                Direcao = "";
                do
                {
                    Direcao = Console.ReadLine();
                } while (Direcao.ToString().Length == 0 || !"X012345".Contains(Direcao));

                /// se teclou X para o programa
                if (Direcao == "X")
                {
                    break;
                }

                /// transforma a ACAO em eNUM - como eu não sei usar o enum nesta situação
                /// comparei o NUMERO do ENUM com o NUMERO da opção de tela.. 
                Int64.TryParse(Direcao, out Int64 nDirecao);

                /// executa a ACAO desejada no elevador desejado.. 
                EdClaraNunes.ElevadorList[Convert.ToInt16(nElevador)].Acao(nDirecao);

            } while (true);

        }
    }
}
