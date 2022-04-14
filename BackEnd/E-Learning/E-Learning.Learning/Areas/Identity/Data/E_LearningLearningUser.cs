using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Learning.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the E_LearningLearningUser class
    public class E_LearningLearningUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
