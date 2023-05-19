namespace GraphTheoryTest
{
    using GraphTheoryTest.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;

    class Testing
    {
        static void Main()
        {
            
            Console.Write("Please input 16 characters in Bulgarian: ");
            string characters = "тгедозваоармпопк";
            StringBuilder solutionsSB = new StringBuilder();
            // CreateTable4Graph();
            string[] allBulgarianWords = File.ReadAllLines("BulgarianWords1.txt");

            //string[] allBulgarianWords = File.ReadAllLines("BulgarianWords.txt");
            //Array.Sort(allBulgarianWords);
            //File.WriteAllLines("BulgarianWords1.txt",allBulgarianWords);

            string[] allGraphPaths = File.ReadAllLines("AllPaths.txt");
            for (int i = 0; i < allBulgarianWords.Length; i++)
                allBulgarianWords[i] = allBulgarianWords[i].ToLower();

            foreach (var path in allGraphPaths)
            {
                var wordAsCollection = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(x => characters[int.Parse(x)]);
                string word = string.Join("", wordAsCollection);
                var index = Array.BinarySearch(allBulgarianWords, word);
                if (index >= 0 && allBulgarianWords[index].Length == word.Length)
                    solutionsSB.Append(word+" ");   
            }
            string[] solutions = solutionsSB.ToString().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            var sortedSolutions = solutions.OrderBy(x => x.Length).ToList();
            for (int i = sortedSolutions.Count-1; i >= 1; i--)
                if (sortedSolutions[i]!=sortedSolutions[i-1])
                    Console.WriteLine(sortedSolutions[i]);
            Console.WriteLine(sortedSolutions[0]);
        }
        private static void CreateTable4Graph()
        {
            Graph<int> tableGraph4 = new Graph<int>();
            for (int i = 0; i < 16; i++)
            {
                tableGraph4.AddVertex(i);
            }

            tableGraph4.AddUndirectedEdge(0, 1);
            tableGraph4.AddUndirectedEdge(0, 4);
            tableGraph4.AddUndirectedEdge(0, 5);

            tableGraph4.AddUndirectedEdge(1, 2);
            tableGraph4.AddUndirectedEdge(1, 4);
            tableGraph4.AddUndirectedEdge(1, 5);
            tableGraph4.AddUndirectedEdge(1, 6);

            tableGraph4.AddUndirectedEdge(2, 3);
            tableGraph4.AddUndirectedEdge(2, 5);
            tableGraph4.AddUndirectedEdge(2, 6);
            tableGraph4.AddUndirectedEdge(2, 7);

            tableGraph4.AddUndirectedEdge(3, 6);
            tableGraph4.AddUndirectedEdge(3, 7);

            tableGraph4.AddUndirectedEdge(4, 5);
            tableGraph4.AddUndirectedEdge(4, 8);
            tableGraph4.AddUndirectedEdge(4, 9);

            tableGraph4.AddUndirectedEdge(5, 6);
            tableGraph4.AddUndirectedEdge(5, 8);
            tableGraph4.AddUndirectedEdge(5, 9);
            tableGraph4.AddUndirectedEdge(5, 10);

            tableGraph4.AddUndirectedEdge(6, 7);
            tableGraph4.AddUndirectedEdge(6, 9);
            tableGraph4.AddUndirectedEdge(6, 10);
            tableGraph4.AddUndirectedEdge(6, 11);

            tableGraph4.AddUndirectedEdge(7, 10);
            tableGraph4.AddUndirectedEdge(7, 11);

            tableGraph4.AddUndirectedEdge(8, 9);
            tableGraph4.AddUndirectedEdge(8, 12);
            tableGraph4.AddUndirectedEdge(8, 13);

            tableGraph4.AddUndirectedEdge(9, 10);
            tableGraph4.AddUndirectedEdge(9, 12);
            tableGraph4.AddUndirectedEdge(9, 13);
            tableGraph4.AddUndirectedEdge(9, 14);

            tableGraph4.AddUndirectedEdge(10, 11);
            tableGraph4.AddUndirectedEdge(10, 13);
            tableGraph4.AddUndirectedEdge(10, 14);
            tableGraph4.AddUndirectedEdge(10, 15);

            tableGraph4.AddUndirectedEdge(11, 14);
            tableGraph4.AddUndirectedEdge(11, 15);

            tableGraph4.AddUndirectedEdge(12, 13);

            tableGraph4.AddUndirectedEdge(13, 14);

            tableGraph4.AddUndirectedEdge(14, 15);

            var allPaths = tableGraph4.GetAllPaths();
            StringBuilder allPathsAsSB = new StringBuilder();
            foreach (var value in allPaths.Values)
            {
                foreach (var vertexList in value)
                {
                    if (vertexList.Count>=3 && vertexList.Count<=10)
                    {
                        foreach (var vertex in vertexList)
                        {
                            allPathsAsSB.Append(vertex.Value);
                            allPathsAsSB.Append(" ");
                        }
                        allPathsAsSB.AppendLine();
                    }   
                }
            }

            string allPathsAsString = allPathsAsSB.ToString();
            File.WriteAllText("AllPaths.txt", allPathsAsString);
        }
    }
}
