using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;

namespace MediatorApiExample.Services;

public class MockTeamMemberService : ITeamMemberService
{
    public List<TeamMember> GetTeamMembers()
    {
        return new List<TeamMember>
        {
            new TeamMember
            {
                Id = "e59023eb-8eff-41fa-9bbb-000ff99153ed",
                Name = "Muhammad",
                Location = new Location
                {
                    Id = "c16aa679-910a-4955-a225-1a13f9b8f607",
                    Country = Country.Pakistan,
                    Region = "Karachi"
                }
            },
            new TeamMember
            {
                Id = "70bcfb62-c5ee-4a43-bfd1-86c0a740ce1a",
                Name = "Daniel",
                Location = new Location
                {
                    Id = "f382364d-7d49-41cf-b827-d11873635fe3",
                    Country = Country.Australian,
                    Region = "New South Wales"
                }
            },
            new TeamMember
            {
                Id = "cf372ad2-67f0-4d3d-9e5f-4389b525b2e8",
                Name = "Maria",
                Location = new Location
                {
                    Id = "20c695f3-b8ae-46c2-96a4-031b5f03855d",
                    Country = Country.Philippines,
                    Region = "Manila"
                }
            }
        };
    }
}
