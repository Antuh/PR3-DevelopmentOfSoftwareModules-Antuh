//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAuthorizations.Module
{
    using System;
    using System.Collections.Generic;
    
    public partial class SocialProgram
    {
        public int ID_SocialProgram { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_Staff { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}
