using LabCibe.OwaspHeaders.Enums;
using LabCibe.OwaspHeaders.Models;

namespace LabCibe.OwaspHeaders.Helpers;

public static class ContentSecurityPolicyHelpers
{
    /// <summary>
    /// Used to create the default "self" CSP directive.
    /// This can be applied to any of the CSP rules individually
    /// or to the 'default-src' rule to cover them all.
    /// </summary>
    /// <returns>
    /// A new instance of the <see cref="ContentSecurityPolicyElement"/>
    /// class which represents a 'self' CSP rule.
    /// </returns>
    public static ContentSecurityPolicyElement CreateSelfDirective()
    {
        return new ContentSecurityPolicyElement
        {
            CommandType = CspCommandType.Directive,
            DirectiveOrUri = "self"
        };
    }

    /// <summary>
    /// Used to create the custom CSP directive..
    /// </summary>
    /// <param name="directiveOrUri">Value to be used for the configuration</param>
    /// <returns>
    /// A new instance of the <see cref="ContentSecurityPolicyElement"/>
    /// class which represents a 'self' CSP rule.
    /// </returns>
    public static List<ContentSecurityPolicyElement> CreateCustomDirectives(string directiveOrUri)
    {
        var result = new List<ContentSecurityPolicyElement>
        {
            CreateSelfDirective(),
            new ContentSecurityPolicyElement
            {
                CommandType = CspCommandType.Directive,
                DirectiveOrUri = "unsafe-inline"
            }
        };

        foreach (var item in directiveOrUri.Split(' '))
        {
            result.Add(new ContentSecurityPolicyElement
            {
                CommandType = CspCommandType.Uri,
                DirectiveOrUri = item
            });
        }

        return result;
    }
}