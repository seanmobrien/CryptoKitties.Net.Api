using System;
using System.Collections.Generic;

namespace CryptoKitties.Net.Api.RestClient.Messages
{
    /// <summary>
    /// Abstract base class shared by service request messages.
    /// </summary>
    public abstract class RequestMessageBase
    {
        /// <summary>
        /// Writes query properties to a query <see cref="Dictionary{TKey,TValue"/>.
        /// </summary>
        /// <param name="target">An optional <see cref="IDictionary{TKey,TValue}"/> values are written to.  If not set a new dictionary will be created.</param>
        /// <returns>The resulting <see cref="IDictionary{TKey,TValue}"/>.</returns>
        public IDictionary<string, string> ToQueryDictionary(IDictionary<string, string> target = default(IDictionary<string, string>))
        {
            var ret = target ?? new Dictionary<string, string>();
            WriteToQueryDictionary(ret);
            return ret;
        }

        /// <summary>
        /// Writes this instance to <paramref name="target"/>.
        /// </summary>
        /// <param name="target"></param>
        protected abstract void WriteToQueryDictionary(IDictionary<string, string> target);
     
        /// <summary>
        /// Writes a <see cref="bool"/> value to <see cref="target"/>.
        /// </summary>
        /// <param name="target">The <see cref="IDictionary{TKey,TValue}"/> values are written to.</param>
        /// <param name="name">A <see cref="string"/> containing the key to update.</param>
        /// <param name="value">The <see cref="bool"/> value to write.</param>
        protected void SetBoolValue(IDictionary<string, string> target, string name, bool? value)
        {
            if (!value.HasValue) return;
            SetValue(target, name, value.ToString(), x => x.ToLowerInvariant());
        }

        /// <summary>
        /// Writes a <typeparamref name="TValue"/> value to <see cref="target"/>.
        /// </summary>
        /// <typeparam name="TValue">The <see cref="Nullable{T}"/> value to write.</typeparam>
        /// <param name="target">The <see cref="IDictionary{TKey,TValue}"/> values are written to.</param>
        /// <param name="name">A <see cref="string"/> containing the key to update.</param>
        /// <param name="value">The <see cref="bool"/> value to write.</param>
        protected void SetValue<TValue>(IDictionary<string, string> target, string name, TValue? value, Func<string, string> formatter = null)
            where TValue : struct 
        {
            if (!value.HasValue) return;
            SetValue(target, name, value.ToString(), formatter);
        }

        /// <summary>
        /// Writes a <typeparamref name="TValue"/> value to <see cref="target"/>.
        /// </summary>
        /// <typeparam name="TValue">The value to write.</typeparam>
        /// <param name="target">The <see cref="IDictionary{TKey,TValue}"/> values are written to.</param>
        /// <param name="name">A <see cref="string"/> containing the key to update.</param>
        /// <param name="value">The <see cref="bool"/> value to write.</param>
        protected void SetValue<TValue>(IDictionary<string, string> target, string name, TValue value, Func<string, string> formatter = null) 
            where TValue : class
        {
            if (value == null) return;
            var v = value.ToString();
            if (formatter != null) v = formatter(v);
            target[name] = v;
        }
    }
}