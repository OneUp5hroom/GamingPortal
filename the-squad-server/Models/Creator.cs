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
        public bool Active { get; set; }



        public Creator(){
                UserId = "NEW";
                UserName = "NEW";
                ProfilePictureUrl = "NEW";
                ProfileDescription = "NEW";
                Games = new List<Game>();
                StreamingServices = new List<StreamingService>();
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
                        Active = false;
                }
        }
        public Creator(IdentityUser user)
        {
                UserId = user.Id;
                UserName = user.UserName;
                Games = new List<Game>();
                StreamingServices = new List<StreamingService>();
                Active = false;
        }
        public Creator(
                IdentityUser user,
                string profilePictureUrl,
                string profileDescription,
                ICollection<Game> games,
                ICollection<StreamingService> streamingServices,
                bool active
        )
        {
                UserId = user.Id;
                UserName = user.UserName;
                ProfilePictureUrl = profilePictureUrl;
                ProfileDescription = profileDescription;
                Games = games;
                StreamingServices = streamingServices;
                Active = active;
        }
}