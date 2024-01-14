using System.Text;

namespace LabCibe.OwaspHeaders.Models;


/// <summary>
/// Represents the HTTP Feature Policy configuration
/// </summary>
public class FeaturePolicy : IConfigurationBase
{
    /// <summary>
    /// Builds the HTTP header value
    /// </summary>
    /// <returns>A string representing the HTTP header value</returns>
    public string BuildHeaderValue()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("geolocation 'none';midi 'none';sync-xhr 'none';microphone 'none';camera 'none';magnetometer 'none';gyroscope 'none';fullscreen 'self';payment 'none';");

        return stringBuilder.ToString();
    }
}