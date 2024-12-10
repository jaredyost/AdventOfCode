namespace AdventOfCode.Solvers.Y2024
{
    public class Day09 : BaseDay2024
    {
        protected override int Day => 9;

        private static readonly int EmptySpaceId = -1;
        private static readonly int InvalidSpaceId = -2;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int[] disk = GetDiskMap(aInput);
            for (int i = 0, j = FindNextBlockIndex(disk, disk.Length - 1); i < j; i++)
            {
                if (disk[i] == EmptySpaceId)
                {
                    disk[i] = disk[j];
                    disk[j] = EmptySpaceId;
                    j = FindNextBlockIndex(disk, j - 1);
                }
            }

            return new(CalculateChecksum(disk).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int[] disk = GetDiskMap(aInput);

            int fileSize = 0;
            int lastBlockId = InvalidSpaceId;
            for (int i = disk.Length - 1; i > 0; i--)
            {
                if (disk[i] == lastBlockId)
                {
                    fileSize++;
                    continue;
                }

                if (lastBlockId != EmptySpaceId && lastBlockId != InvalidSpaceId)
                {
                    int freeBlockStart = InvalidSpaceId;
                    for (int j = 0; j <= i; j++)
                    {
                        if (disk[j] != EmptySpaceId)
                        {
                            freeBlockStart = InvalidSpaceId;
                            continue;
                        }

                        if (freeBlockStart == InvalidSpaceId)
                        {
                            freeBlockStart = j;
                        }

                        if (j - freeBlockStart + 1 >= fileSize)
                        {
                            for (int k = 0; k < fileSize; k++)
                            {
                                disk[freeBlockStart + k] = lastBlockId;
                                disk[i + fileSize - k] = EmptySpaceId;
                            }

                            break;
                        }
                    }
                }

                fileSize = 1;
                lastBlockId = disk[i];
            }

            return new(CalculateChecksum(disk).ToString());
        }

        private static int[] GetDiskMap(string[] aDiskMap)
        {
            List<int> disk = [];
            int currentBlockId = 0;
            bool isFreeSpace = false;
            foreach (int size in aDiskMap.SelectMany(x => x.ToCharArray()).Select(x => int.Parse(x.ToString())))
            {
                for (int i = 0; i < size; i++)
                {
                    disk.Add(isFreeSpace ? EmptySpaceId : currentBlockId);
                }

                currentBlockId += isFreeSpace ? 0 : 1;
                isFreeSpace = !isFreeSpace;
            }

            return [.. disk];
        }

        private static int FindNextBlockIndex(int[] aDisk, int aStartingIndex)
        {
            while (aStartingIndex >= 0 && aDisk[aStartingIndex] == EmptySpaceId)
            {
                aStartingIndex--;
            }

            return aStartingIndex;
        }

        private static ulong CalculateChecksum(int[] aDisk)
        {
            ulong checksum = 0;
            for (int i = 0; i < aDisk.Length; i++)
            {
                if (aDisk[i] != EmptySpaceId)
                {
                    checksum += Convert.ToUInt64(i * aDisk[i]);
                }
            }

            return checksum;
        }
    }
}
