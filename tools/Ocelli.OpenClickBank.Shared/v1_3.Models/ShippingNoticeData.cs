//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.1.1179.0
namespace v1_3.Models
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.1179.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("shippingNoticeData", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("shippingNoticeData", Namespace="")]
    public partial class ShippingNoticeData
    {
        
        [System.Xml.Serialization.XmlElementAttribute("shipDate", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, DataType="dateTime")]
        public System.Nullable<System.DateTime> ShipDate { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("carrier", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Carrier { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("trackingId", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string TrackingId { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("shippedTo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ShippedTo { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("comments", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Comments { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("receipt", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Receipt { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("itemNo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ItemNo { get; set; }
    }
}
