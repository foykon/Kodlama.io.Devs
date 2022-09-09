using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int DeveloperId { get; set; }
        public string ProfileUrl { get; set; }
        public virtual Developer Developer { get; set; }

        public GitHubProfile()
        {

        }
        
        public GitHubProfile(int id, int developerId, string profileUrl) : this()
        {
            Id = id;
            DeveloperId = developerId;
            ProfileUrl = profileUrl;
        }
    }
}