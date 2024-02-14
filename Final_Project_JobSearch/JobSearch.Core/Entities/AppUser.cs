﻿using Microsoft.AspNetCore.Identity;

namespace JobSearch.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Company>? Companies { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
    }
}
