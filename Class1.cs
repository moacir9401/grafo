using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta
{
    class Class1
    {
        public static void Imprime(int[,] mat)
        {
            int tamanho = (int)Math.Sqrt(mat.Length);
            Console.WriteLine("\n");
            for (int i = 0; i < tamanho; ++i)
            {
                int x = 0;

                if (i == 0)
                {
                    for (int t = 0; t < tamanho; t++)
                    {
                        if (t == 0)
                        {
                            Console.Write($"  |e{t + 1}|");
                            continue;
                        }
                        Console.Write($"|e{t + 1}|");
                    }
                    Console.Write("\n");
                }
                Console.Write($"v{i + 1}");
                for (int j = 0; j < tamanho; ++j)
                {
                    Console.Write("|");

                    if (mat[i, j] != -1)
                    {
                        Console.Write(" 1|");
                    }
                    else
                    {
                        Console.Write(" 0|");
                    }

                }

                Console.Write("\n");
            }
        }
       
        public static void ImprimeLetra(int[,] mat)
        {
            // imprimir grau
            string map_letra = "ABCDEFGHIK";
            int tamanho = (int)Math.Sqrt(mat.Length);
            int i, j;
            for (i = 0; i < tamanho; ++i)
            {
                Console.Write("amigos de " + map_letra[i]);

                for (j = 0; j < tamanho; ++j)
                {
                    Console.Write("\t");
                    if (mat[i, j] != -1)
                    {
                        Console.Write(map_letra[mat[i, j]]);
                    }
                }
                Console.Write("\n");
            }
        }
        public static void ImprimeConjuno(int[,] mat)
        {

            int i, j, tamanho;

            tamanho = (int)Math.Sqrt(mat.Length);

            for (i = 0; i < tamanho; ++i)
            {

                if (i == 0)
                {
                    Console.Write("V={");
                    for (int t = 0; t < tamanho; t++)
                    {
                        Console.Write($"{t},");
                    }

                    Console.Write("}");
                }
                for (j = 0; j < tamanho; ++j)
                {

                    if (mat[i, j] != -1)
                    {
                        if (i == 0) Console.Write(" A=");

                        Console.Write("{" + (int)(i + 1) + ",");
                        Console.Write(mat[i, j] + 1 + "},");


                    }
                }

            }
        } public static void ImprimeGrau(int[,] mat)
        {
            // imprimir grau

            int i, j, grau;
            int tamanho = (int)Math.Sqrt(mat.Length);
            for (i = 0; i < 5; ++i)
            {
                grau = 0;
                for (j = 0; j < 5; ++j)
                {
                    if (mat[i, j] == 1)
                    {
                        grau++;
                    }
                }
                Console.Write($"\no grau da verticie {i + 1} é {grau}");
            }

        }
        public static void tem_ligacao(int[,] vetor, int tamanho)
        {

            int[,] newMat = new int[tamanho, tamanho];
            int i, j;
            for (i = 0; i < tamanho; ++i)
            {
                for (j = 0; j < tamanho; ++j)
                {
                    if (vetor[i, j] == 1)
                    {
                        newMat[i, j] = j;
                    }
                    else
                    {
                        newMat[i, j] = -1;
                    }
                }
            }

            Imprime(newMat);
        }

        public static void Converter(int[,] mat, int tamanho)
        {
            int[,] newMat = new int[tamanho, tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (mat[i, i] == 1 && mat[i, j] == 1)
                    {
                        newMat[i, -j] = 1;
                    }
                    else
                    {
                        newMat[i, j] = -1;
                    }
                }
            }


            Imprime(newMat);
        }


    }
}
