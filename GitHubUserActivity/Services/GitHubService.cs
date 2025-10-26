using Octokit;
using GitHubUserActivity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubUserActivity.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _githubClient;

        public GitHubService()
        {
            _githubClient = new GitHubClient(new ProductHeaderValue("GitHubUserActivityApp"));
        }

        public async Task<GitHubUser> GetUserInfo(string username)
        {
            Octokit.User user = await _githubClient.User.Get(username);
            return new GitHubUser
            {
                Login = user.Login,
                Name = user.Name,
                Bio = user.Bio,
                Followers = user.Followers,
                Following = user.Following,
                PublicRepos = user.PublicRepos,
                AvatarUrl = user.AvatarUrl,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<List<CustomRepo>> GetUserRepositories(string username)
        {
            IReadOnlyList<Repository> octokitRepos = await _githubClient.Repository.GetAllForUser(username);
            return octokitRepos.Select(repo => new CustomRepo
            {
                Name = repo.Name ?? "No name",
                Description = repo.Description,
                StargazersCount = repo.StargazersCount,
                ForksCount = repo.ForksCount,
                HtmlUrl = repo.HtmlUrl
            }).ToList();
        }

        public async Task<List<ActivityEvent>> GetUserActivity(string username)
        {
            IReadOnlyList<Activity> events = await _githubClient.Activity.Events.GetAllUserPerformed(username);
            return events.Select(e => new ActivityEvent
            {
                Type = e.Type.ToString(),
                RepoName = e.Repo.Name,
                CreatedAt = e.CreatedAt
            }).ToList();
        }
    }
}