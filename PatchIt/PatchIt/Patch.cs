using System;
using System.Runtime.CompilerServices;


namespace PatchIt
{
    /**
     * @author Ahmed F.Shark<ahmad360pro@gmail.com>
     * @version 1.1.0.0
     * @link https://github.com/AhaTheGhost/cs-patchit/
     */

    /// <summary>
    /// A class for patching binary data.
    /// </summary>

    public class BinaryPatcher : IDisposable
    {
        // The array to be patched.
        private byte[] byteArray;
        public string LastLog;

        // Constant representing the library name.
        const string LIB_NAME = "PatchIt";

        // Constructor for initializing the BinaryPatcher.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public BinaryPatcher(byte[] byteArray)
        {
            // Check if the input byte array is null and throw an exception if it is.
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray), $"{LIB_NAME}: Input byte array cannot be null.");

            this.byteArray = byteArray;
            LastLog = "Initialized";
        }

        // Method to apply binary patches to the byte array.
        public void PatchData(byte[][] patchPairs)
        {
            IsPatchPairsSizeValid(patchPairs);

            try
            {
                ApplyPatches(patchPairs);
                LastLog = "Success";
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException($"{LIB_NAME} Error: Index out of range - {ex.Message}", ex);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"{LIB_NAME} Error: {e.Message}", e);
            }
        }

        // Method to apply the patches to the byte array.
        private void ApplyPatches(byte[][] patchPairs)
        {
            try
            {
                // Iterate through the patchPairs and apply each patch.
                for (int i = 0; i < patchPairs.Length; i += 2)
                {
                    byte[] findBinary = patchPairs[i];
                    byte[] replaceBinary = patchPairs[i + 1];

                    // Search for the 'findBinary' sequence in the byteArray and replace it with 'replaceBinary'.
                    for (int j = 0; j <= byteArray.Length - findBinary.Length; j++)
                    {
                        if (isSequenceValid(byteArray, j, findBinary))
                        {
                            for (int k = 0; k < findBinary.Length; k++)
                                byteArray[j + k] = replaceBinary[k];
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LastLog = $"Error: {e.Message}";
            }
        }

        // Method to check if a sequence is valid at a given position in the byte array.
        private bool isSequenceValid(byte[] byteArray, int startIndex, byte[] sequenceToFind)
        {
            // Check if the 'findBinary' sequence can fit within the 'byteArray' starting from 'startIndex'.
            if (startIndex + sequenceToFind.Length > byteArray.Length)
                return false;

            // Compare each byte of 'findBinary' with the corresponding byte in 'byteArray'.
            for (int i = 0; i <= sequenceToFind.Length - 1; i++)
                if (sequenceToFind[i] != byteArray[startIndex + i])
                    return false;

            return true;
        }

        // Method to check if the size of patchPairs is valid (even number of elements).
        private bool IsPatchPairsSizeValid(byte[][] patchPairs)
        {
            if (patchPairs.Length % 2 != 0)
                throw new ArgumentException($"{LIB_NAME}: The patchPairs must contain an equal number of 'find' and 'replace' patterns, size of array must be even.\nSize of array: {patchPairs.Length}");

            return true;
        }

        /// <returns>The patched byte array.</returns>
        public byte[] GetPatchedBinary()
        {
            return byteArray;
        }

        /// <returns>The last log message.</returns>
        public string GetLastLog()
        {
            return LastLog;
        }

        // Dispose method to release resources.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Dispose method for releasing resources.
        protected virtual void Dispose(bool disposing)
        {
            byteArray = null;
            LastLog = null;
        }
    }
}