using OpenClickBank.Builder.Data;

namespace OpenClickBank.Builder.Models;

public class ContractBean
{
    public ContractContact[]? Contacts { get; set; }
    public int Id { get; set; }
    public ContractStatus Status { get; set; }
}