namespace BankSystem.BLL.Interface.Interfaces
{
    using Entities.Accounts;

    /// <summary>
    /// Exposes a calculator of bank operations bonuses
    /// </summary>
    public interface IBonusCalculator
    {
        /// <summary>
        /// Gets the deposit bonus.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// Count of deposit bonus points
        /// </returns>
        int GetDepositBonus(Account account, decimal amount);

        /// <summary>
        /// Gets the withdraw bonus.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// Count of withdraw bonus points
        /// </returns>
        int GetWithdrawBonus(Account account, decimal amount);
    }
}
