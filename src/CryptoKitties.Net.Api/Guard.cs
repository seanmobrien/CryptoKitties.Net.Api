using System;

namespace CryptoKitties.Net
{
    /// <summary>
    /// stock argument validation
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws if <paramref name="instance"/> is null.
        /// </summary>
        /// <param name="instance">The <see cref="string"/> to evaluate.</param>
        /// <param name="paramName">Name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance"/> is invalid.</exception>

        public static void NotNull<T>(T instance, string paramName) where T : class
        {
            if (instance == null) throw new ArgumentNullException(paramName);
        }
        /// <summary>
        /// Throws if <paramref name="instance"/> is null or empty.
        /// </summary>
        /// <param name="instance">The <see cref="string"/> to evaluate.</param>
        /// <param name="paramName">Name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance"/> is invalid.</exception>

        public static void NotEmpty(string instance, string paramName)
        {
            if (string.IsNullOrEmpty(instance)) throw new ArgumentNullException(paramName);
        }
        /// <summary>
        /// Throws if <paramref name="instance"/> is null or all whitespace.
        /// </summary>
        /// <param name="instance">The <see cref="string"/> to evaluate.</param>
        /// <param name="paramName">Name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance"/> is invalid.</exception>
        public static void NotWhitespace(string instance, string paramName)
        {
            if (string.IsNullOrWhiteSpace(instance)) throw new ArgumentNullException(paramName);
        }
    }
}
