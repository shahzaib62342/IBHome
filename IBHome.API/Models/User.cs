using System.ComponentModel.DataAnnotations;

namespace IBHome.API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; } = false;
        public bool IsEmailConfirmed { get; set; } = false;
        
        public UserType? UserType { get; set; }

        public Guid UserTypeID { get; set; }
        public string SocialType { get; set; } = "Instagram";
        public string SocialUserName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public int FollowersCount { get; set; }
        public int OrdersCount { get; set; }
        public bool IsVerified { get; set; } = false;
        public string Token { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Rating { get; set; }
        public int OrderCount { get; set; }
        public int TotalStars { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastUpdatedOn { get; set; }
        public string FCMToken { get; set; }
        public string Expertise { get; set; }
        public string Achivements { get; set; }
        public bool IsAllowLogin { get; set; }
    }
}
