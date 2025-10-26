using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserActivity.Models
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int PublicRepos { get; set; }
        public string AvatarUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
