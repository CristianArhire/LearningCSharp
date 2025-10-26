using GitHubUserActivity.Models;
using GitHubUserActivity.Services;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubUserActivity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("GitHub User Activity Viewer");
            Console.WriteLine("--------------------------");

            GitHubService githubService = new GitHubService();

            Console.Write("Enter GitHub username: ");
            string username = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            try
            {
                GitHubUser user = await githubService.GetUserInfo(username);
                DisplayUserInfo(user);

                List<CustomRepo> repos = await githubService.GetUserRepositories(username);
                DisplayTopRepositories(repos);

                List<ActivityEvent> activities = await githubService.GetUserActivity(username);
                DisplayRecentActivity(activities);
            }
            catch (NotFoundException)
            {
                Console.WriteLine($"User '{username}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayUserInfo(GitHubUser user)
        {
            Console.WriteLine("\nUser Information:");
            Console.WriteLine($"- Name: {user.Name ?? "N/A"} ({user.Login})");
            Console.WriteLine($"- Bio: {user.Bio ?? "No bio available"}");
            Console.WriteLine($"- Followers: {user.Followers} | Following: {user.Following}");
            Console.WriteLine($"- Public Repos: {user.PublicRepos}");
            Console.WriteLine($"- Joined GitHub: {user.CreatedAt:yyyy-MM-dd}");
        }

        static void DisplayTopRepositories(List<CustomRepo> repos)
        {
            Console.WriteLine("\nTop Repositories (by stars):");
            foreach (var repo in repos.OrderByDescending(r => r.StargazersCount).Take(5))
            {
                Console.WriteLine($"- {repo.Name} (⭐ {repo.StargazersCount})");
                if (!string.IsNullOrEmpty(repo.Description))
                {
                    Console.WriteLine($"  Description: {repo.Description}");
                }
                if (!string.IsNullOrEmpty(repo.HtmlUrl))
                {
                    Console.WriteLine($"  URL: {repo.HtmlUrl}");
                }
            }
        }

        static void DisplayRecentActivity(List<ActivityEvent> activities)
        {
            Console.WriteLine("\nRecent Activity:");
            foreach (var activity in activities.Take(5))
            {
                Console.WriteLine($"- {activity.Type} at {activity.RepoName} ({activity.CreatedAt:g})");
            }
        }
    }
}