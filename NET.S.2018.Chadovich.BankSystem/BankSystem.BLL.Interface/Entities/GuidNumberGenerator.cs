namespace BankSystem.BLL.Interface.Entities
{
    using System;
    using Interfaces;

    public class GuidNumberGenerator : INumberGenerator
    {
        public string GenerateNew() => Guid.NewGuid().ToString();
    }
}
