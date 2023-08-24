using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_squad_server.Models;

public class StreamingService
{
    public int StreamingServiceId { get; set; }
    [Required]
    public string Name { get; set; }
    [Url]
    public string LogoUrl { get; set; }
    [Url]
    public string? ServiceUrl { get; set; }
    [Url]
    public string? VideoUrl { get; set; }
    public bool Generic { get; set; }
    
    [ForeignKey("CreatorId")]
    [InverseProperty("StreamingServices")]
    public virtual Creator? CreatorAssignment { get; set; }

    public StreamingService()
    {

    }

    public StreamingService(string name, string logoUrl, string videoUrl, string serviceUrl)
    {
        Name = name;
        LogoUrl = logoUrl;
        VideoUrl = videoUrl;
        ServiceUrl = serviceUrl;
    }
    public StreamingService(StreamingService _ss)
    {
        StreamingServiceId = 0;
        Name = _ss.Name;
        LogoUrl = _ss.LogoUrl;
        VideoUrl = _ss.VideoUrl;
        ServiceUrl = _ss.ServiceUrl;
        Generic = false;
    }



}