﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class BankAccount
    {
        private readonly AccountHolder holder;
        
        private int bonusPoints;

        private readonly IMoneyAccuracyCalculator rounder;

        protected BankAccount(string id, AccountHolder holder, IMoneyAccuracyCalculator rounder)
        {
            ValidateOnNull(holder, nameof(holder));
            ValidateOnNull(rounder, nameof(rounder));

            this.Id = id;
            this.rounder = rounder;
            this.holder = holder;
        }
        
        public string Id { get; }

        public AccountStatus Status { get; set; }
        
        public decimal Balance { get; protected set; }

        public void Deposit(decimal amount)
        {
            ValidateOnStatus(nameof(this.Deposit));

            decimal roundedAmount = this.rounder.RoundUp(amount);

            ValidateOnAmount(roundedAmount, nameof(amount));
            
            IncreaseBalance(roundedAmount);
            IncreaseBonusPoints(roundedAmount);
        }

        public void Withdraw(decimal amount)
        {
            ValidateOnStatus(nameof(this.Withdraw));

            decimal roundedAmount = this.rounder.RoundUp(amount);

            ValidateOnAmount(roundedAmount, nameof(amount));

            DecreaseBalance(roundedAmount);
            DecreaseBonusPoints(roundedAmount);
        }

        protected abstract void IncreaseBalance(decimal amount);

        protected abstract void DecreaseBalance(decimal amount);

        protected abstract void IncreaseBonusPoints(decimal amount);

        protected abstract void DecreaseBonusPoints(decimal amount);

        private static void ValidateOnNull<T>(T obj, string name) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
        }

        private static void ValidateOnAmount(decimal amount, string name)
        {
            if (amount <= 0M)
            {
                throw new ArgumentOutOfRangeException($"{name} must be positive to be performed");
            }
        }

        private void ValidateOnStatus(string operationName)
        {
            if (this.Status != AccountStatus.Open)
            {
                throw new InvalidOperationException($"{operationName} cannot be executed " +
                                                    $"while account status is not {nameof(AccountStatus.Open)}");
            }
        }
    }
}