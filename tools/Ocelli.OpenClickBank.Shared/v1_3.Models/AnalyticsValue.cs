//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.719.0
namespace v1_3.Models
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.719.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("analyticsValue", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AnalyticsValue
    {
        
        public virtual bool ShouldSerializeAttribute()
        {
            return Attribute.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("attribute", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<AnalyticAttribute> Attribute { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("value", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public object Value { get; set; }
    }
}
