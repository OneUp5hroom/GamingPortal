using Microsoft.Extensions.Configuration;

namespace the_squad_server.Models;

public class GraphSettings
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? TenantId { get; set; }

    public GraphSettings(string clientId, string clientSecret, string tenantId)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        TenantId = tenantId;
    }
}