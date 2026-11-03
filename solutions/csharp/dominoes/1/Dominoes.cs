
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var tiles = dominoes.ToList();

        if (tiles.Count == 0)
            return true;

        var graph = new Dictionary<int, List<int>>();
        var degree = new Dictionary<int, int>();

        foreach (var (a, b) in tiles)
        {
            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();

            graph[a].Add(b);
            graph[b].Add(a);

            degree[a] = degree.GetValueOrDefault(a) + 1;
            degree[b] = degree.GetValueOrDefault(b) + 1;
        }

        if (degree.Values.Any(d => d % 2 != 0))
            return false;

        var visited = new HashSet<int>();
        var stack = new Stack<int>();
        stack.Push(tiles[0].Item1);

        while (stack.Count > 0)
        {
            int current = stack.Pop();

            if (!visited.Add(current))
                continue;

            foreach (int neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                    stack.Push(neighbor);
            }
        }

        return degree.Keys.All(visited.Contains);
    }
}