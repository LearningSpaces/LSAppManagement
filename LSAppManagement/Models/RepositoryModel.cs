using LSAppManagement.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSAppManagement.Models
{
    public class RepositoryModel
    {
        public List<CommitModel> Commits
        {
            get
            {
                return GitHubHelper.GetCommits(this);
            }
        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("owner")]
        public  UserModel Owner { get; set; }
        [JsonProperty("private")]
        public bool Private { get; set; }
        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("fork")]
        public bool Fork { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("forks_url")]
        public string ForksUrl { get; set; }
        [JsonProperty("keys_url")]
        public string KeysUrl { get; set; }
        [JsonProperty("collaborators_url")]
        public string CollaboratorsUrl { get; set; }
        [JsonProperty("teams_url")]
        public string TeamsUrl { get; set; }
        [JsonProperty("hooks_url")]
        public string HooksUrl { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("pushed_at")]
        public DateTime PushedAt { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }
        [JsonProperty("watchers_count")]
        public int WatchersCount { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }
        [JsonProperty("permissions")]
        public PermissionModel Permissions { get; set; }
        [JsonProperty("organization")]
        public UserModel OrganizationModel { get; set; }
    }
}