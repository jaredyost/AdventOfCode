namespace AdventOfCode.Core.Helpers.Types
{
    public class MixedRadix
    {
        #region Properties
        public ulong TotalStates { get; private init; }

        private ulong[] Strides { get; init; }
        #endregion

        #region Constructors
        public MixedRadix(int[] aTargetState)
        {
            Strides = new ulong[aTargetState.Length];
            Strides[^1] = 1;
            for (int i = Strides.Length - 2; i >= 0; i--)
            {
                Strides[i] = Strides[i + 1] * ((ulong)aTargetState[i + 1] + 1);
            }

            TotalStates = Strides[0] * ((ulong)aTargetState[0] + 1);
        }
        #endregion

        #region Methods
        public int[] Decode(ulong aId)
        {
            int[] state = new int[Strides.Length];
            Decode(aId, ref state);
            return state;
        }

        public void Decode(ulong aId, ref int[] aState)
        {
            if (aState.Length != Strides.Length)
            {
                throw new ArgumentException("Invalid state provided!", nameof(aState));
            }

            for (int i = 0; i < Strides.Length; i++)
            {
                aState[i] = (int)(aId / Strides[i]);
                aId %= Strides[i];
            }
        }

        public ulong Encode(int[] aState)
        {
            if (aState.Length != Strides.Length)
            {
                throw new ArgumentException("Invalid state provided!", nameof(aState));
            }

            ulong id = 0;
            for (int i = 0; i < Strides.Length; i++)
            {
                id += (ulong)aState[i] * Strides[i];
            }

            return id;
        }
        #endregion
    }
}
