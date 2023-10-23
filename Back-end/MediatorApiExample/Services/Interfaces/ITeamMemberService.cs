using MediatorApiExample.Models;

namespace MediatorApiExample.Services.Interfaces;

public interface ITeamMemberService
{
    List<TeamMember> GetTeamMembers();
}