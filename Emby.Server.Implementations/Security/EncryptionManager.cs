using System;
using System.Text;
using MediaBrowser.Controller.Security;

namespace Emby.Server.Implementations.Security
{
    public class EncryptionManager : IEncryptionManager
    {
        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">value</exception>
        public string EncryptString(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return EncryptStringUniversal(value);
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">value</exception>
        public string DecryptString(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return DecryptStringUniversal(value);
        }

        private static string EncryptStringUniversal(string value)
        {
            // Yes, this isn't good, but ProtectedData in mono is throwing exceptions, so use this for now

            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        private static string DecryptStringUniversal(string value)
        {
            // Yes, this isn't good, but ProtectedData in mono is throwing exceptions, so use this for now

            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
