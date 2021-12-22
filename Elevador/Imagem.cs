using System;

namespace FinalElevador
{

    /// <summary>
    /// Ia fazer uma coletanea de telas apra subir e descer o elevador.. 
    /// desisti então so ficou o quadrinho parano maximo 2 elevadores.. 
    /// </summary>
    public class Imagem
    {

        


        public String cOcupacao = @"
+-------------+-------------+-------------+
|  Elevador   |      0      |      1      |
+-------------+-------------+-------------+
|  TotalAndar |     TA0     |     TA1     |
+-------------+-------------+-------------+
|  Max Passag |     MX0     |     MX1     |
+-------------+-------------+-------------+
|  AndarAtual |     AA0     |     AA1     |
+-------------+-------------+-------------+
|  Nome Andar |   NA0  |   NA1  |
+-------------+-------------+-------------+
|  Ocup Atual |     OA0     |     OA1     |
+-------------+-------------+-------------+
|  VoceDentro |    VCD0     |    VCD1     |
+-------------+-------------+-------------+
|    STATUS   | STATUSATUA0 | STATUSATUA1 |
+-------------+-------------+-------------+
";

        /// <summary>
        /// partes nao usadas .. fazer o elevador subir e descer.. 
        /// </summary>
        static void imagem()
        {



            String vazUnd = @"
                             
                             
                             
                             
                             
=============================
";
            String vazUpp = @"
=============================
                             
                             
                             
                             
                             
                             
";

            String[] aElev = {
@"
                             
=======+-------------+=======
       |      |      |
       |      |      |
       |      |      |
       |      |      |
       |      |      |
       |      |      |
=======+-------------+=======
",
@"
                             
       +-------------+       
=======|      |      |=======
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
       +-------------+       
=============================
",
@"
                             
       +-------------+       
       |      |      |       
=======|      |      |=======
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
       +-------------+       
                             
=============================
",
@"
                             
       +-------------+       
       |      |      |       
       |      |      |       
=======|      |      |=======
       |      |      |       
       |      |      |       
       |      |      |       
       +-------------+       
                             
                             
=============================
",
@"
                                     
       +-------------+       
       |      |      |       
       |      |      |       
       |      |      |       
=======|      |      |=======
       |      |      |       
       |      |      |       
       +-------------+       
                             
                             
                             
=============================
",
@"
                             
       +-------------+       
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
=======|      |      |=======
       |      |      |       
       +-------------+       
                             
                             
                             
                             
=============================
",
@"
                             
       +-------------+       
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
       |      |      |       
=======|      |      |=======
       +-------------+       
                             
                             
                             
                             
                             
=============================
",

        };


            int nposElev = -1;
            Int64 nAndar = 0;
            do
            {
                Console.Clear();
                if (nAndar >= aElev.Length)
                {
                    nposElev++;
                    nAndar = 0;

                }
                Console.WriteLine(aElev[nAndar]);
                for (int i = 0; i <= (nposElev); i++)
                {
                    Console.WriteLine(vazUnd);

                }

                nAndar = Int64.Parse(Console.ReadLine());
                if (nAndar == 0)
                {
                    nposElev--;
                }

            }
            while (nAndar != 9);


        }

    }
}
