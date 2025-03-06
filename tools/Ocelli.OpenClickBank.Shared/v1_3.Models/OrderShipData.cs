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
    [System.Xml.Serialization.XmlTypeAttribute("orderShipData", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("orderShipData", Namespace="")]
    public partial class OrderShipData
    {
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("receipt", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Receipt { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("firstName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string FirstName { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("lastName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string LastName { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("email", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Email { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("address1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Address1 { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("address2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Address2 { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("city", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string City { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("state", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string State { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("country", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Country { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("postalCode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string PostalCode { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("transactionTime", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, DataType="dateTime")]
        public System.Nullable<System.DateTime> TransactionTime { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("isTestTransaction", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<bool> IsTestTransaction { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("fullName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string FullName { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("vendor", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string Vendor { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<VendorVariableElement> _vendorVariables;
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlArrayAttribute("vendorVariables", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Collections.ObjectModel.Collection<VendorVariableElement> VendorVariables
        {
            get
            {
                return _vendorVariables;
            }
            set
            {
                _vendorVariables = value;
            }
        }
        
        public virtual bool ShouldSerializeVendorVariables()
        {
            return ((this.VendorVariables != null) 
                        && (this.VendorVariables.Count != 0));
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<OrderShipLineItemData> _lineItemShipData;
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("lineItemShipData", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Collections.ObjectModel.Collection<OrderShipLineItemData> LineItemShipData
        {
            get
            {
                return _lineItemShipData;
            }
            set
            {
                _lineItemShipData = value;
            }
        }
        
        public virtual bool ShouldSerializeLineItemShipData()
        {
            return ((this.LineItemShipData != null) 
                        && (this.LineItemShipData.Count != 0));
        }
    }
}
