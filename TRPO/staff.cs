//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TRPO
{
    using System;
    using System.Collections.Generic;
    
    public partial class staff
    {
        public int staff_id { get; set; }
        public string familia { get; set; }
        public string imya { get; set; }
        public string otchestvo { get; set; }
        public int salary { get; set; }
        public int position_id { get; set; }
    
        public virtual position position { get; set; }
    }
}
