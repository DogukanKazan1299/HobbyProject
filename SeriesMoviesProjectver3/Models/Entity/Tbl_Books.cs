//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeriesMoviesProjectver3.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Books
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }
        public Nullable<System.DateTime> ReleaseYear { get; set; }
        public string Image { get; set; }
        public Nullable<int> Category { get; set; }
    
        public virtual Tbl_Category Tbl_Category { get; set; }
    }
}
