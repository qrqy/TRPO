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
    
    public partial class product
    {
        public int product_id { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public int price { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> length { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> count { get; set; }
        public int classification_id { get; set; }
        public string name { get; set; }
        public virtual classification classification { get; set; }
        public virtual supplier supplier { get; set; }

        public string GetClassification() { return this.classification.classification1; }
        public string name_Les30 { get { return name.Length < 30 ? name : name.Substring(0, 30); } set { } }
    }
}
