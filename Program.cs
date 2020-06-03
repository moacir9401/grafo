using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta
{
    class Program
    {

        public static int[,] AdicionarSequencia(string texto)
        {
            var verifica = true;
            string entrada;
            int tamanho;
            int[,] matriz;
            string[] sequencia;

            do
            {
                Console.WriteLine("");

                entrada = Console.ReadLine();
                sequencia = entrada.Trim().Split(',');

                verifica = VerificarEntrada(sequencia);

                tamanho = sequencia.Length;
                matriz = new int[tamanho, tamanho];

                for (int i = 0; i < tamanho; i++)
                {
                    for (int j = 0; j < tamanho; j++)
                    {
                        int valor;
                        if (int.TryParse(sequencia[j], out valor))
                        {
                            matriz[i, j] = valor;
                        }

                    }
                }
            } while (!verifica);

            var x = matriz.Length;

            return matriz;
        }

        public static Grafo CriarGrafo()
        {
            var matriz = AdicionarSequencia("Digite uma sequência de números separados por ,");
            Console.WriteLine("Criado com sucesso");
            return new Grafo(matriz);
        }

        public static void Menu()
        {
            int opcao;
            Grafo grafo = new Grafo();

            do
            {
                Console.WriteLine("\n 0 - Sair " + 
                                  "\n 1 - Criar Grafo " +
                                  "\n 2 - Adicionar Aresta " +
                                  "\n 3 - Imprimir Matriz Adjacente " +
                                  "\n 4 - Imprimir Matriz Incidência " +
                                  "\n 5 - Imprimir Grau de uma Vertice" +
                                  "\n 6 - Imprimir Todos Grau de Vertices" +
                                  "\n 7 - Imprimir Conjunto de Vértices e Arestas");

                Console.WriteLine("Digite uma opção");
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Código invalido");
                    continue;
                }
                if (opcao != 1 && !grafo.isGrafo)
                {
                    Console.WriteLine("Primeiro crie um grafo");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        grafo = CriarGrafo();
                        break;
                    case 2:
                        AdicionarAresta(grafo);
                        break;
                    case 3:
                        grafo.imprimeGrafoAdjacente(grafo);
                        break;
                    case 4:
                        grafo.imprimeGrafo(grafo);
                        break;
                    case 5:
                        GrauVertice(grafo);
                        break;
                    case 6:
                        GrauTodosVertice(grafo);
                        break;
                    case 7:
                        grafo.ImprimeConjuno(grafo);
                        break;
                    case 0:
                        return;
                }

            } while (true);

        }

        private static void GrauVertice(Grafo grafo)
        {
            int vertice;
            do
            {
                try
                {
                    Console.WriteLine("Digite o número da vertice");

                    if (!int.TryParse(Console.ReadLine(), out vertice))
                    {
                        Console.WriteLine("Código invalido");
                        continue;
                    }
                    foraIntervalo(grafo.getQtdVertices(), vertice);

                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            } while (true);
            grafo.ImprimeGrau(grafo, vertice - 1);
        }
        private static void GrauTodosVertice(Grafo grafo)
        {

            grafo.ImprimeGrau(grafo);
        }


        public static void foraIntervalo(int valorTotal, int valor2)
        {
            if (valor2 < 0 || valorTotal < valor2)
                throw new ArgumentException("fora do intervalo");
        }
        private static void AdicionarAresta(Grafo grafo)
        {
            do
            {
                try
                {
                    var matriz = AdicionarSequencia("Digite os dois vertices separado com , e para sair digite 0");
                    if (matriz[0, 0] == 0)
                    {
                        break;
                    }

                        foraIntervalo(grafo.getQtdVertices(), matriz[0, 0]);
                        foraIntervalo(grafo.getQtdVertices(), matriz[0, 1]);

                    grafo.addAresta(grafo.getVertice(matriz[0, 0] - 1), grafo.getVertice(matriz[0, 1] - 1));
                    Console.WriteLine("Aresta adicionada com sucesso");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            } while (true);
        }

        public static bool VerificarEntrada(string[] values)
        {
            List<string> listValues = new List<string>();
            listValues.AddRange(values);
            try
            {
                // Verifica se contem na lista
                if (!listValues.Where(item => !string.IsNullOrWhiteSpace(item)).Any()) throw new ArgumentException("A seguência deve conter pelo menos 1 número");

                // Verfiicar se contem apenas números
                int inteiro;
                bool numeroValido = true;
                listValues.ForEach(item => numeroValido = int.TryParse(item, out inteiro));
                if (!numeroValido) throw new ArgumentException("A seguência deve conter apenas número");

                //// Verifica se contem itens duplicados
                //if (listValues.Distinct().Count() != listValues.Count()) throw new ArgumentException("A seguência não pode conter número duplicados");

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}