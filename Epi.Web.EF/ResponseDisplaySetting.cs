//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epi.Web.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResponseDisplaySetting
    {
        public System.Guid FormId { get; set; }
        public string ColumnName { get; set; }
        public int SortOrder { get; set; }
    
        public virtual SurveyMetaData SurveyMetaData { get; set; }
    }
}
