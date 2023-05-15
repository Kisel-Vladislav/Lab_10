namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] roadMatrix = 
            {
                { -1, 150, 50, -1 },
                { -1, -1, 70, 10 },
                { -1, -1, -1, 70 },
                { 40, -1, -1, -1 }
            };

            int startCity = 0;
            int targetCity = 3;

            List<List<int>> dfsPaths = FindPathsDFS(roadMatrix, startCity, targetCity);
            List<List<int>> bfsPaths = FindPathsBFS(roadMatrix, startCity, targetCity);

            Console.WriteLine("DFS:");
            foreach (List<int> path in dfsPaths)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }

            Console.WriteLine("BFS:");
            foreach (List<int> path in bfsPaths)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        static List<List<int>> FindPathsDFS(int[,] roadMatrix, int startCity, int targetCity)
        {
            int numCities = roadMatrix.GetLength(0);
            bool[,] visited = new bool[numCities, numCities];
            List<List<int>> paths = new List<List<int>>();

            Stack<List<int>> stack = new Stack<List<int>>();
            stack.Push(new List<int> { startCity });

            while (stack.Count > 0)
            {
                List<int> currentPath = stack.Pop();
                int currentCity = currentPath[currentPath.Count - 1];

                if (currentCity == targetCity)
                {
                    paths.Add(currentPath);
                    continue;
                }

                for (int i = 0; i < numCities; i++)
                {
                    if (roadMatrix[currentCity, i] != -1 && !visited[i, currentCity])
                    {
                        List<int> newPath = new List<int>(currentPath);
                        newPath.Add(i);
                        stack.Push(newPath);
                        visited[i, currentCity] = true;
                    }
                }
            }

            return paths;
        }

        static List<List<int>> FindPathsBFS(int[,] roadMatrix, int startCity, int targetCity)
        {
            int numCities = roadMatrix.GetLength(0);
            bool[,] visited = new bool[numCities, numCities];
            List<List<int>> paths = new List<List<int>>();

            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int> { startCity });

            while (queue.Count > 0)
            {
                List<int> currentPath = queue.Dequeue();
                int currentCity = currentPath[currentPath.Count - 1];

                if (currentCity == targetCity)
                {
                    paths.Add(currentPath);
                    continue;
                }

                for (int i = 0; i < numCities; i++)
                {
                    if (roadMatrix[currentCity, i] != -1 && !visited[i, currentCity])
                    {
                        List<int> newPath = new List<int>(currentPath);
                        newPath.Add(i);
                        queue.Enqueue(newPath);
                        visited[i, currentCity] = true;
                    }
                }
            }

            return paths;
        }
    }
}