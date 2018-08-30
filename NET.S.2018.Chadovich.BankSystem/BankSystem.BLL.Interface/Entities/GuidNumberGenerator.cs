namespace BankSystem.BLL.Interface.Entities
{
    using System;
    using Interfaces;

    /// <summary>
    /// Exposes a bank number generator which uses <seealso cref="Guid"/>
    /// </summary>
    /// <seealso cref="BankSystem.BLL.Interface.Interfaces.INumberGenerator" />
    public class GuidNumberGenerator : INumberGenerator
    {
        /// <summary>
        /// Generates the new bank account number.
        /// </summary>
        /// <returns>
        /// New bank account number
        /// </returns>
        public string GenerateNew() => Guid.NewGuid().ToString();
    }
}
