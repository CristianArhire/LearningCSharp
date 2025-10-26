using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserActivity.Models
{
    public class CustomRepo
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }
        public int StargazersCount { get; set; }
        public int ForksCount { get; set; }
        public string HtmlUrl { get; set; }

    }
}
