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
    [System.Xml.Serialization.XmlTypeAttribute("ProductDataCategories", Namespace="", AnonymousType=true)]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProductDataCategories
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<ProductCategory> _category;
        
        [System.Xml.Serialization.XmlElementAttribute("category", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.ObjectModel.Collection<ProductCategory> Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        
        public virtual bool ShouldSerializeCategory()
        {
            return ((this.Category != null) 
                        && (this.Category.Count != 0));
        }
    }
}
