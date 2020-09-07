using System.Collections.Generic;
using System.Linq;
using Bogus;
using Resumes.Api.Models;

namespace Resumes.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Profiles.Any())
            {
                return;   // DB has been seeded
            }
            var photoUrls = new System.Collections.Generic.List<string>
            {
                "https://images.unsplash.com/photo-1524952249965-023a2a31663d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1531427186611-ecfd6d936c79?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1499996860823-5214fcc65f8f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1531384698654-7f6e477ca221?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1524154217857-45f012d0f167?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1595085610896-fb31cfd5d4b7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1530785896884-7929f3dd1954?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60",
                "https://images.unsplash.com/photo-1591727884968-cc11135a19b3?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60"
            };

            var phoneNumbers = new List<string>
            {
                "0715541233",
                "0714441233",
                "0718841233",
                "0719941233",
                "0712241277",
                "0712241255",
                "0712241200",
                "0712241123",
                "0712241888",
                "0712241489",
            };

            var profileFaker = new Faker<Profile>()
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.LastName))
            .RuleFor(x => x.PhoneNo, f => f.PickRandom(phoneNumbers))
            .RuleFor(x => x.Website, (f, u) => f.Internet.UrlWithPath())
            .RuleFor(x => x.PhotoUrl, f => f.PickRandom(photoUrls));

            var profiles = profileFaker.Generate(10);

            context.Profiles.AddRange(profiles);
            context.SaveChanges();
        }
    }
}