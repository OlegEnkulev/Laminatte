//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laminatte.Resources
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime DateTime { get; set; }
        public int Status { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
