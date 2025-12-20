using System.Numerics;
using Connection = AdventOfCode.Core.Helpers.UnorderedPair<System.Numerics.Vector3>;
using ConnectionData = System.Collections.Generic.KeyValuePair<
    AdventOfCode.Core.Helpers.UnorderedPair<System.Numerics.Vector3>,
    float
>;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day08 : BaseDay2025
    {
        protected override int Day => 8;

        public int NumberPairs { private get; set; } = 1000;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<Vector3> junctionBoxes =
            [
                .. aInput
                    .Select(x => x.Split(','))
                    .Select(x => new Vector3(
                        float.Parse(x[0]),
                        float.Parse(x[1]),
                        float.Parse(x[2])
                    )),
            ];

            Dictionary<Connection, float> connections = [];
            for (int i = 0; i < junctionBoxes.Count; i++)
            {
                for (int j = i + 1; j < junctionBoxes.Count; j++)
                {
                    Connection connection = new(junctionBoxes[i], junctionBoxes[j]);
                    if (!connections.ContainsKey(connection))
                    {
                        connections.Add(
                            connection,
                            Vector3.Distance(connection.Item1, connection.Item2)
                        );
                    }
                }
            }
            List<ConnectionData> sortedConnections = [.. connections.OrderBy(x => x.Value)];

            List<List<ConnectionData>> circuits = [];
            for (int i = 0; i < NumberPairs; i++)
            {
                // TODO: Link up the junction boxes
            }
            circuits = [.. circuits.OrderByDescending(x => x.Count)];

            return new((circuits[0].Count * circuits[1].Count * circuits[2].Count).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(0.ToString());
        }
    }
}
