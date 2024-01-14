using LabCibe.OwaspHeaders.Enums;
using LabCibe.OwaspHeaders.Helpers;

namespace LabCibe.OwaspHeaders.Models;


public class PermittedCrossDomainPolicyConfiguration : IConfigurationBase
{
    public XPermittedCrossDomainOptionValue XPermittedCrossDomainOptionValue { get; set; }

    protected PermittedCrossDomainPolicyConfiguration()
    {
    }

    public PermittedCrossDomainPolicyConfiguration(
        XPermittedCrossDomainOptionValue permittedCrossDomainOptionValue)
    {
        XPermittedCrossDomainOptionValue = permittedCrossDomainOptionValue;
    }

    public string BuildHeaderValue()
    {
        switch (XPermittedCrossDomainOptionValue)
        {
            case XPermittedCrossDomainOptionValue.none:
                return "none;";
            case XPermittedCrossDomainOptionValue.masterOnly:
                return "master-only;";
            case XPermittedCrossDomainOptionValue.byContentType:
                return "by-content-type;";
            case XPermittedCrossDomainOptionValue.byFtpFileType:
                return "by-ftp-file-type;";
            case XPermittedCrossDomainOptionValue.all:
                return "all;";
            default:
                ArgumentExceptionHelper.RaiseException(nameof(XPermittedCrossDomainOptionValue));
                break;
        }
        return ";";
    }
}