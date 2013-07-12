using System;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    public interface ICryptographyService
    {
        /// <summary>
        /// Encrypts the specified plain string.
        /// </summary>
        /// <param name="plainString">The plain string.</param>
        /// <returns></returns>
        string Encrypt(string plainString, string cryptographyKey);

        /// <summary>
        /// Decrypts the specified encrypted string.
        /// </summary>
        /// <param name="encryptedString">The encrypted string.</param>
        /// <returns></returns>
        string Decrypt(string encryptedString, string cryptographyKey);
    }
}
