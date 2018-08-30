namespace BankSystem.BLL.Interface.Interfaces
{
    using System.Collections.Generic;
    using Entities;
    using Entities.Accounts;

    /// <summary>
    /// Exposes a service which supports methods to manage bank accounts
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Opens new bank account for specified holder
        /// </summary>
        /// <param name="holder">The holder.</param>
        void Open(AccountHolder holder);

        /// <summary>
        /// Closes account with specified number
        /// </summary>
        /// <param name="number">The number of the account</param>
        void Close(string number);

        /// <summary>
        /// Deposits the specified amount to the account by given number
        /// </summary>
        /// <param name="number">The number of the account</param>
        /// <param name="amount">The amount</param>
        void Deposit(string number, decimal amount);

        /// <summary>
        /// Withdraws the specified amount from the account by given number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="amount">The amount.</param>
        void Withdraw(string number, decimal amount);

        /// <summary>
        /// Transfers the specified amount of money from sender account to recipient
        /// by thier given numbers
        /// </summary>
        /// <param name="senderNumber">The sender number.</param>
        /// <param name="recipientNumber">The recipient number.</param>
        /// <param name="amount">The amount.</param>
        void Transfer(string senderNumber, string recipientNumber, decimal amount);

        /// <summary>
        /// Gets all accounts of specified holder
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <returns>
        /// The sequence of accounts
        /// </returns>
        IEnumerable<Account> GetAll(AccountHolder holder);

        /// <summary>
        /// Gets account by given number of the specified holder
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <param name="number">The number.</param>
        /// <returns>
        /// Wanted account
        /// </returns>
        Account Get(AccountHolder holder, string number);
    }
}
