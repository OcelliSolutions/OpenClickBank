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
    [System.Xml.Serialization.XmlTypeAttribute("orderShipLineItemData", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class OrderShipLineItemData
    {
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("itemNo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ItemNo { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("productTitle", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ProductTitle { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("customerAmount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> CustomerAmount { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("accountAmount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> AccountAmount { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("quantity", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> Quantity { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("shippingMethod", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ShippingMethod { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("isRefundPending", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<bool> IsRefundPending { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("hasBeenRefunded", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<bool> HasBeenRefunded { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("hasBeenChargebacked", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<bool> HasBeenChargebacked { get; set; }
    }
}
