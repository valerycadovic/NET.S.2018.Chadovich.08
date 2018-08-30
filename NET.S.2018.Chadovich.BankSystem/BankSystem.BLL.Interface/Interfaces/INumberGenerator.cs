namespace BankSystem.BLL.Interface.Interfaces
{
    /// <summary>
    /// Exposes a bank number generator
    /// </summary>
    public interface INumberGenerator
    {
        /// <summary>
        /// Generates the new bank account number.
        /// </summary>
        /// <returns>
        /// New bank account number
        /// </returns>
        string GenerateNew();
    }
}
