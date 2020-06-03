using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta
{
    class Grafo
    {

        private ArrayList arestas;
        private ArrayList vertices;
        private int[,] matrizAdjacencia;
        private int[,] matrizIncidencia;
        private Boolean isOrientado;
        public bool isGrafo { get; set; }

        public Grafo()
        {
            isGrafo = false;
        }

        //	Cria um grafo usando matriz de adjacencia
        public Grafo(int[,] matriz)
        {
            vertices = new ArrayList();
            arestas = new ArrayList();
            this.isOrientado = false;
            for (int i = 0; i < Math.Sqrt(matriz.Length); i++)
            {
                this.addVertice();
            }
            for (int i = 0; i < Math.Sqrt(matriz.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matriz.Length); j++)
                {
                    if (matriz[i, j] == 1)
                    {
                        //Vertice v1 = this.getVertice(i);
                        //Vertice v2 = this.getVertice(j);
                        //this.addAresta(v1, v2);
                    }
                }
            }

            isGrafo = true;
        }



        public Vertice addVertice()
        {
            Vertice v = new Vertice();
            v.nome = this.getNovoNome();
            v.setRotulo(v.nome + "");
            vertices.Add(v);
            this.updateMatrizAdjacencias();
            this.updateMatrizIncidencias();
            return (v);
        }


        public Aresta addAresta(Vertice _v1, Vertice _v2)
        {
            if (this.getArestaEntreVertices(_v1, _v2) == null)
            {
                Aresta aresta = new Aresta(_v1, _v2);
                arestas.Add(aresta);

                this.updateMatrizAdjacencias();
                this.updateMatrizIncidencias();
                return (aresta);
            }
            return (null);
        }

        public Aresta getArestaEntreVertices(Vertice _v1, Vertice _v2)
        {
            Aresta aresta;
            for (int i = 0; i < arestas.Count; i++)
            {
                aresta = getAresta(i);
                if (aresta.contemAresta(_v1, _v2))
                    return (aresta);
            }
            return (null);
        }


        private int getNovoNome()
        {
            return (vertices.Count + 1);
        }
        public void ImprimeGrau(Grafo grafo)
        {
            // imprimir grau

            int i, j, grau;
            int tamanho = grafo.getQtdVertices();
            for (i = 0; i < tamanho; ++i)
            {
                grau = 0;
                for (j = 0; j < tamanho; ++j)
                {
                    if (grafo.matrizAdjacencia[i, j] == 1)
                    {
                        grau++;
                    }
                }
                Console.Write($"\nO grau da verticie {i + 1} é {grau}");
            }

        }

        public void ImprimeConjuno(Grafo grafo)
        {

            int i, j, tamanho;

            List<string> list = new List<string>();

            tamanho = grafo.getQtdVertices();

            var mat = tem_ligacao(grafo.matrizAdjacencia, tamanho);

            for (i = 0; i < tamanho; ++i)
            {

                if (i == 0)
                {
                    Console.Write("V={");
                    for (int t = 0; t < tamanho; t++)
                    {
                        if(t < tamanho -1)
                        Console.Write($"{t+1},");
                        else
                            Console.Write($"{t + 1}");
                    }

                    Console.Write("}");
                }
                if (i == 0) Console.Write(" A=");
                for (j = 0; j < tamanho; ++j)
                {
                    var x = i.ToString() + j;
                    if (mat[i, j] != -1)
                    {
                        if (!list.Contains(mat[i, j].ToString() + i))
                        {
                            
                            Console.Write("{" + (int)(i + 1) + ",");
                            Console.Write(mat[i, j] + 1 + "},");
                            list.Add(i.ToString() + mat[i, j]);
                        }
                    }
                }

            }
            Console.Write("\n");
        }

        public int[,] tem_ligacao(int[,] vetor, int tamanho)
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
            return newMat;
        }

        public void ImprimeGrau(Grafo grafo, int vertice)
        {
            // imprimir grau

            int i, j, grau;
            int tamanho = grafo.getQtdVertices();

            grau = 0;
            for (j = 0; j < tamanho; ++j)
            {
                if (grafo.matrizAdjacencia[vertice, j] == 1)
                {
                    grau++;
                }
            }
            Console.Write($"\nO grau da vertice {vertice + 1} é {grau}");
        }


        public void tem_ligacao(Grafo grafo)
        {

            ImprimeGrau(grafo);
        }
        public Vertice getVertice(int i)
        {
            var x = ((Vertice)vertices[i]);
            return ((Vertice)vertices[i]);
        }
        public Aresta getAresta(int i)
        {
            return ((Aresta)arestas[i]);
        }

        public ArrayList getAdjacencias(Vertice v)
        {
            Aresta aresta;
            ArrayList adjacencias = new ArrayList();
            for (int i = 0; i < arestas.Count; i++)
            {
                aresta = getAresta(i);
                if (aresta.getV1() == v)
                {
                    adjacencias.Add(aresta.getV2());
                }
                if (aresta.getV2() == v)
                {
                    adjacencias.Add(aresta.getV1());
                }
            }

            return (adjacencias);
        }


        private void updateMatrizAdjacencias()
        {
            Vertice vertice;
            Vertice verticeAux;
            ArrayList v_adjacencias;
            matrizAdjacencia = new int[vertices.Count, vertices.Count];


            for (int i = 0; i < vertices.Count; i++)
            {
                vertice = this.getVertice(i);
                v_adjacencias = this.getAdjacencias(vertice);
                for (int j = 0; j < v_adjacencias.Count; j++)
                {
                    verticeAux = (Vertice)v_adjacencias[j];
                    matrizAdjacencia[i, verticeAux.nome - 1] = 1;
                }
            }
        }
        private void updateMatrizIncidencias()
        {
            Aresta aresta;
            matrizIncidencia = new int[vertices.Count, arestas.Count];

            for (int j = 0; j < arestas.Count; j++)
            {
                aresta = getAresta(j);
                matrizIncidencia[aresta.getV1().nome - 1, j] = 1;
                matrizIncidencia[aresta.getV2().nome - 1, j] = 1;
            }
        }



        public int getQtdVertices()
        {
            return vertices.Count;
        }

        public void imprimeGrafoAdjacente(Grafo grafo)
        {
            int i, j;
            Console.WriteLine(" ");
            for (i = 0; i <= (grafo.getQtdVertices() - 1); i++)
            {
                for (int t = 0; t < grafo.getQtdVertices(); t++)
                {
                    if (t == 0)
                    {
                        Console.Write($"  |v{t + 1}|");
                        continue;
                    }
                    Console.Write($"v{t + 1}|");
                }
                Console.Write("\n");
                for (i = 0; i <= (grafo.getQtdVertices() - 1); i++)
                {
                    Console.Write($"v{i + 1}");
                    Console.Write("|");
                    for (j = 0; j <= (grafo.getQtdVertices() - 1); j++)
                    {

                        if (grafo.matrizAdjacencia[i, j] == 1)
                        {
                            Console.Write(grafo.matrizAdjacencia[i, j] + " |");
                        }
                        else
                        {
                            Console.Write(grafo.matrizAdjacencia[i, j] + " |");
                        }
                    }
                    Console.Write("\n");
                }
            }
        }

        public void imprimeGrafo(Grafo grafo)
        {
            int i, j;
            Console.WriteLine(" ");
            for (i = 0; i <= (grafo.getQtdVertices() - 1); i++)
            {
                for (int t = 0; t < grafo.getQtdVertices(); t++)
                {
                    if (t == 0)
                    {
                        Console.Write($"  |e{t + 1}|");
                        continue;
                    }
                    Console.Write($"e{t + 1}|");
                }
                Console.Write("\n");
                for (i = 0; i <= (grafo.getQtdVertices() - 1); i++)
                {
                    Console.Write($"v{i + 1}");
                    Console.Write("|");
                    for (j = 0; j <= (grafo.getQtdVertices() - 1); j++)
                    {

                        if (grafo.matrizIncidencia[i, j] == 1)
                        {
                            Console.Write(grafo.matrizIncidencia[i, j] + " |");
                        }
                        else
                        {
                            Console.Write(grafo.matrizIncidencia[i, j] + " |");
                        }
                    }
                    Console.Write("\n");
                }
            }
        }
    }
}
