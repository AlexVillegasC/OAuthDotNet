using LabCibe.OwaspHeaders.Enums;

namespace LabCibe.OwaspHeaders.Models;

public class ContentSecurityPolicyElement
{
    public CspCommandType CommandType { get; set; }
    public string DirectiveOrUri { get; set; }
}
