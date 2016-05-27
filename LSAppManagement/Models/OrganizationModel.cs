using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LSAppManagement.Helpers;

namespace LSAppManagement.Models
{
    public class UserModel
    {
        public List<RepositoryModel> Repos
        {
            get
            {
                return GitHubHelper.GetOrgRepos(Id);
            }
        }

        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }
        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }
        [JsonProperty("hooks_url")]
        public string HooksUrl { get; set; }
        [JsonProperty("issues_url")]
        public string IssuesUrl { get; set; }
        [JsonProperty("members_url")]
        public string MembersUrl { get; set; }
        [JsonProperty("public_members_url")]
        public string PublicMembersUrl { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("blog")]
        public string Blog { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("public_repos")]
        public int PublicReposCount { get; set; }
        [JsonProperty("public_gists")]
        public int PublicGistsCount { get; set; }
        [JsonProperty("followers")]
        public int FollowersCount { get; set; }
        [JsonProperty("following")]
        public int FollowingCount { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("total_private_repos")]
        public int TotalPrivateReposCount { get; set; }
        [JsonProperty("owned_private_repos")]
        public int OwnedPrivateReposCount { get; set; }
        [JsonProperty("private_gists")]
        public int PrivateGistsCount { get; set; }
        [JsonProperty("disk_usage")]
        public int DiskUsage { get; set; }
        [JsonProperty("collaborators")]
        public int CollaboratorsCount { get; set; }
        [JsonProperty("billing_email")]
        public string BillingEmail { get; set; }
        [JsonProperty("plan")]
        public PlanModel Plan { get; set; }
    }
}