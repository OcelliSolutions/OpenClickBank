using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

public class ContractBean
{
    public ContractContact[]? Contacts { get; set; }
    public int Id { get; set; }
    public ContractStatus Status { get; set; }
}