using System;
using System.Runtime.CompilerServices;

namespace PatchIt
{
    public class Patch : IDisposable
    {

        private byte[] FindBinary;
        private byte[] ReplaceBinary;
        private byte[] ByteArray;
        public string LastLog;

        [MethodImpl(MethodImplOptions.NoInlining)]

        public Patch(byte[] byteArray)
        {
            ByteArray = byteArray;
        }

        public void patchData(byte[][] array)
        {

            if (isArraySizeVaild(array))
                buffer(array);

        }

        private void buffer(byte[][] array)
        {

            try
            {

                for (int i = 0; i < array.Length; i += 2)
                {

                    FindBinary = array[i];
                    ReplaceBinary = array[i + 1];

                    for (int F = 0; F <= ByteArray.Length - 1; F++)
                    {
                        if (!isSequenceVaild(ByteArray, F))
                            continue;
                        else
                        {
                            for (int R = 0; R <= FindBinary.Length - 1; R++)
                                ByteArray[F + R] = ReplaceBinary[R];
                            break;
                        }
                    }

                }

                LastLog = "success";

            }
            catch (Exception e)
            {
                LastLog = "error: " + e;
            }

        }

        private bool isArraySizeVaild(byte[][] array)
        {

            if (array.Length % 2 != 0)
            {
                LastLog = "The array must contain as many \"find\" sub arraies as \"replace\" arraies. Size of Find and Replace Array: " + array.Length;
                return false;
            }

            return true;

        }

        private bool isSequenceVaild(byte[] seq, int pos)
        {

            if (pos + FindBinary.Length > seq.Length)
                return false;

            for (int i = 0; i <= FindBinary.Length - 1; i++)
                if (FindBinary[i] != seq[pos + i])
                    return false;

            return true;
        }

        public byte[] getPatchedData()
        {
            return ByteArray;
        }

        public string getlastLog()
        {
            return LastLog;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            FindBinary = null;
            ReplaceBinary = null;
            LastLog = null;
        }

    }
}