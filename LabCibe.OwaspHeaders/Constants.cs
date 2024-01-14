namespace LabCibe.OwaspHeaders;

public static class Constants
{
    public static readonly string StrictTransportSecurityHeaderName = "Strict-Transport-Security";

    public static readonly string XFrameOptionsHeaderName = "X-Frame-Options";

    public static readonly string XssProtectionHeaderName = "X-XSS-Protection";

    public static readonly string XContentTypeOptionsHeaderName = "X-Content-Type-Options";

    public static readonly string ContentSecurityPolicyHeaderName = "Content-Security-Policy";

    public static readonly string ContentSecurityPolicyReportOnlyHeaderName = "Content-Security-Policy-Report-Only";

    public static readonly string XContentSecurityPolicyHeaderName = "X-Content-Security-Policy";

    public static readonly string PermittedCrossDomainPoliciesHeaderName = "X-Permitted-Cross-Domain-Policies";

    public static readonly string ReferrerPolicyHeaderName = "Referrer-Policy";

    public static readonly string ExpectCtHeaderName = "Expect-CT";

    public static readonly string PoweredByHeaderName = "X-Powered-By";

    public static readonly string FeaturePolicyHeaderName = "Feature-Policy";

    public static readonly string PermissionsPolicyHeaderName = "Permissions-Policy";

    public static readonly string ServerHeaderName = "Server";
}

public static class CsdsContentPolicy
{
    public static readonly string Base = "self ";
    public static readonly string Style = "self unsafe-inline dn.jsdelivr.net cdnjs.cloudflare.com cdn.cookielaw.org www.google.com platform.twitter.com cdn.syndication.twimg.com fonts.googleapis.com fonts.gstatic.com cdnjs.cloudflare.com *.fontawesome.com";
    public static readonly string Script = "self unsafe-inline js.stripe.com code.jquery.com cdnjs.cloudflare.com labcibe-gateway-dev.azurewebsites.net labcibe-client-oauth-dev.azurewebsites.net localhost:7095"; // Set URLs here to enable CORS.    
    public static readonly string Font = "self unsafe-inline cdnjs.cloudflare.com cdn.cookielaw.org fonts.googleapis.com fonts.gstatic.com *.fontawesome.com https://consent.trustarc.com";
    public static readonly string FrameAncestor = "self ";
}