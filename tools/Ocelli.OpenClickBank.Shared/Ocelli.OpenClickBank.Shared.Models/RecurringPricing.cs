//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.719.0
namespace Ocelli.OpenClickBank.Shared.Models
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.719.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("recurringPricing", Namespace="")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("recurring", Namespace="")]
    public partial class RecurringPricing
    {
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("price")]
        public Price Price { get; set; }
        
        public virtual bool ShouldSerializeFrequency()
        {
            return Frequency.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("frequency", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<RecurringFrequency> Frequency { get; set; }
        
        public virtual bool ShouldSerializeDuration()
        {
            return Duration.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("duration", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<int> Duration { get; set; }
        
        public virtual bool ShouldSerializeTrial_Days()
        {
            return Trial_Days.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("trial_days", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<int> Trial_Days { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("pre_rebill_override", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool Pre_Rebill_Override { get; set; }
        
        public virtual bool ShouldSerializePre_Rebill_Leadtime()
        {
            return Pre_Rebill_Leadtime.HasValue;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("pre_rebill_leadtime", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<int> Pre_Rebill_Leadtime { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("recurringTitle", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RecurringTitle { get; set; }
        
        [System.Diagnostics.CodeAnalysis.AllowNullAttribute()]
        [System.Diagnostics.CodeAnalysis.MaybeNullAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("recurringDescription", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RecurringDescription { get; set; }
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("frequencyValue", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int FrequencyValue { get; set; }
    }
}