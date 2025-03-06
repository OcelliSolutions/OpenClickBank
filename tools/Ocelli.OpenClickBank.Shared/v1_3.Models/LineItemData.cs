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
    [System.Xml.Serialization.XmlTypeAttribute("lineItemData", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LineItemData
    {
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("itemNo", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ItemNo { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("productTitle", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string ProductTitle { get; set; }
        
        public virtual bool ShouldSerializeRecurring()
        {
            return Recurring.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("recurring", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<bool> Recurring { get; set; }
        
        public virtual bool ShouldSerializeShippable()
        {
            return Shippable.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("shippable", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<bool> Shippable { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("customerAmount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> CustomerAmount { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("accountAmount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> AccountAmount { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("quantity", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> Quantity { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("lineItemType", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string LineItemType { get; set; }
        
        public virtual bool ShouldSerializeRefundsBlocked()
        {
            return RefundsBlocked.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("refundsBlocked", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<bool> RefundsBlocked { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("rebillAmount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<decimal> RebillAmount { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("processedPayments", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> ProcessedPayments { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("futurePayments", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> FuturePayments { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("nextPaymentDate", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, DataType="dateTime")]
        public System.Nullable<System.DateTime> NextPaymentDate { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("status", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Status { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("role", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Role { get; set; }
    }
}
