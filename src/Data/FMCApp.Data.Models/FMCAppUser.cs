using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Data.Models
{
    // Add profile data for application users by adding properties to the FMCAppUser class
    public class FMCAppUser : IdentityUser
    {
        public FMCAppUser()
        {
            this.Comments = new HashSet<Comment>();
            this.WatchLists = new HashSet<WatchList>();
        }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<WatchList> WatchLists { get; set; }
    }
}
