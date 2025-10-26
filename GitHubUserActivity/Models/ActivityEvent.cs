using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserActivity.Models
{
    public class ActivityEvent
    {
        public string Type { get; set; }
        public string RepoName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
