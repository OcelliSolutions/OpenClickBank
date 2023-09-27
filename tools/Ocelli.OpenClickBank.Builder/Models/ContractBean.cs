using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ContractBean
{
    public ContractContact[]? Contacts { get; set; }
    public int Id { get; set; }
    public ContractStatus Status { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
