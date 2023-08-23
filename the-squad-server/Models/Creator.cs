using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_squad_server.Models;

public class Creator
{
        [Key]
        public int CreatorId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        [Required]
        [Url]
        public string? ProfilePictureUrl { get; set; }
        [Required]
        [StringLength(2048,ErrorMessage = "{0} length must be between {2} and {1} characters.", MinimumLength = 6)]
        public string? ProfileDescription { get; set; }
        
        public ICollection<Game>? Games { get; set;}

        public ICollection<StreamingService>? StreamingServices { get; set;}
        [Url]
        public string? TwitchUrl { get; set; }
        [Url]
        public string? YoutubeUrl { get; set; }
        [Url]
        public string? KickUrl { get; set; }
        [Url]
        public string? TikTokUrl { get; set; }
        [Url]
        public string? InstagramUrl { get; set; }
        [Url]
        public string? FacebookUrl { get; set; }
        [Url]
        public string? GithubUrl { get; set; }
        [Url]
        public bool Active { get; set; }



        public Creator(){
                UserId = "NEW";
                UserName = "NEW";
                ProfilePictureUrl = "NEW";
                ProfileDescription = "NEW";
                Games = new List<Game>();
                StreamingServices = new List<StreamingService>();
                TwitchUrl = "NEW";
                YoutubeUrl = "NEW";
                KickUrl = "NEW";
                TikTokUrl = "NEW";
                InstagramUrl = "NEW";
                FacebookUrl = "NEW";
                GithubUrl = "NEW";
                Active = false;
        }
        public Creator(bool Default){
                if (Default)
                {
                        UserId = "Default";
                        UserName = "Default";
                        ProfilePictureUrl = "Default";
                        ProfileDescription = "Default";
                        Games = new List<Game>();
                        StreamingServices = new List<StreamingService>();
                        TwitchUrl = "Default";
                        YoutubeUrl = "Default";
                        KickUrl = "Default";
                        TikTokUrl = "Default";
                        InstagramUrl = "Default";
                        FacebookUrl = "Default";
                        GithubUrl = "Default";
                        Active = false;
                }
        }
        public Creator(IdentityUser user)
        {
                UserId = user.Id;
                UserName = user.UserName;
                Active = false;
        }
        public Creator(
                IdentityUser user,
                string profilePictureUrl,
                string profileDescription,
                ICollection<Game> games,
                ICollection<StreamingService> streamingServices,
                string? twitchUrl,
                string? youtubeUrl,
                string? kickUrl,
                string? tikTokUrl,
                string? instagramUrl,
                string? facebookUrl,
                string? githubUrl,
                bool active
        )
        {
                UserId = user.Id;
                UserName = user.UserName;
                ProfilePictureUrl = profilePictureUrl;
                ProfileDescription = profileDescription;
                Games = games;
                StreamingServices = streamingServices;
                TwitchUrl = twitchUrl;
                YoutubeUrl = youtubeUrl;
                KickUrl = kickUrl;
                TikTokUrl = tikTokUrl;
                InstagramUrl = instagramUrl;
                FacebookUrl = facebookUrl;
                GithubUrl = githubUrl;
                Active = active;
        }
}