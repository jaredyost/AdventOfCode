using System.Numerics;
using Connection = AdventOfCode.Core.Helpers.UnorderedPair<System.Numerics.Vector3>;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day08 : BaseDay2025
    {
        protected override int Day => 8;

        public int NumberPairs { private get; set; } = 1000;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            // Get the sorted junction box connections
            Vector3[] junctionBoxes = GetJunctionBoxes(aInput);
            Connection[] sortedConnections = GetSortedConnections(junctionBoxes);

            // Seed the circuits with the junction boxes
            List<List<Vector3>> circuits = [];
            foreach (Vector3 junctionBox in junctionBoxes)
            {
                circuits.Add(new([junctionBox]));
            }

            // Connect together the specified number of junction boxes
            for (int i = 0; i < NumberPairs; i++)
            {
                Connection connection = sortedConnections[i];
                List<Vector3> circuit1 = circuits.First(x => x.Contains(connection.Item1));
                List<Vector3> circuit2 = circuits.First(x => x.Contains(connection.Item2));

                if (circuit1 != circuit2)
                {
                    circuit1.AddRange(circuit2);
                    circuits.Remove(circuit2);
                }
            }

            // Sort the circuits based off most connections
            circuits = [.. circuits.OrderByDescending(x => x.Count)];

            // Utilize the 3 longest circuits
            return new((circuits[0].Count * circuits[1].Count * circuits[2].Count).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            // Get the sorted junction box connections
            Vector3[] junctionBoxes = GetJunctionBoxes(aInput);
            Connection[] sortedConnections = GetSortedConnections(junctionBoxes);

            // Seed the circuits with the junction boxes
            List<List<Vector3>> circuits = [];
            foreach (Vector3 junctionBox in junctionBoxes)
            {
                circuits.Add(new([junctionBox]));
            }

            // Connect together all of the junction boxes
            Connection lastConnection = sortedConnections[0];
            for (int i = 0; circuits.Count > 1; i++)
            {
                Connection connection = sortedConnections[i];
                List<Vector3> circuit1 = circuits.First(x => x.Contains(connection.Item1));
                List<Vector3> circuit2 = circuits.First(x => x.Contains(connection.Item2));

                if (circuit1 != circuit2)
                {
                    lastConnection = connection;
                    circuit1.AddRange(circuit2);
                    circuits.Remove(circuit2);
                }
            }

            // Utilize the X-coordinate of the last connection made
            ulong result = (ulong)lastConnection.Item1.X * (ulong)lastConnection.Item2.X;
            return new(result.ToString());
        }

        private static Vector3[] GetJunctionBoxes(string[] aInput)
        {
            return
            [
                .. aInput
                    .Select(x => x.Split(','))
                    .Select(x => new Vector3(
                        float.Parse(x[0]),
                        float.Parse(x[1]),
                        float.Parse(x[2])
                    )),
            ];
        }

        private static Connection[] GetSortedConnections(Vector3[] aJunctionBoxes)
        {
            // Calculate the distance between every junction box
            Dictionary<Connection, float> connections = [];
            for (int i = 0; i < aJunctionBoxes.Length; i++)
            {
                for (int j = i + 1; j < aJunctionBoxes.Length; j++)
                {
                    Connection connection = new(aJunctionBoxes[i], aJunctionBoxes[j]);
                    if (!connections.ContainsKey(connection))
                    {
                        connections.Add(
                            connection,
                            Vector3.Distance(connection.Item1, connection.Item2)
                        );
                    }
                }
            }

            // Sort the connections based off short distance
            return [.. connections.OrderBy(x => x.Value).Select(x => x.Key)];
        }
    }
}
