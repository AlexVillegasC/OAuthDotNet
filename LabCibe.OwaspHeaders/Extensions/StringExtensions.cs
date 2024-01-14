namespace LabCibe.OwaspHeaders.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Used to ensure that a passed URI (see <paramref name="uri"/>) is a valid URI.
    /// </summary>
    /// <param name="uri">The URI to check</param>
    /// <returns>Whether the supplied URI is valid or not (true if so, false otherwise</returns>
    /// <remarks>Enforces HTTPS for URI</remarks>
    public static bool IsValidHttpsUri(this string uri)
    {
        return Uri.TryCreate(uri, UriKind.Absolute, out Uri uriResult)
               && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}