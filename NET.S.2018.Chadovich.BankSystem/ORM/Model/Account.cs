//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public string IBAN { get; set; }
        public int Bonuses { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public string HolderId { get; set; }
        public int TypeSettingsId { get; set; }
    
        public virtual Holder Holder { get; set; }
        public virtual TypeSetting TypeSetting { get; set; }
    }
}