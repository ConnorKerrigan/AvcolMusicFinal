﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AvcolMusicFinal.Areas.Identity.Data
{

    // Add profile data for application users by adding properties to the ACUser class
    public class ACUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }

}