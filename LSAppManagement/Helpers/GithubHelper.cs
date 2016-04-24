using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LSAppManagement.Helpers
{
    public static class GitHubHelper
    {
        private static _BasicAuth = new Credentials("seabass992","Seabass_992");
        private static GitHubClient client = new GitHubClient(new ProductHeaderValue("LSAppManagement"), _BasicAuth);

        public static Organization GetOrg(){
            return await client.Organization.Get("LearningSpaces");
        }

        public static List<Repository> GetRepos()
        {
            var repos = await client.Repository.GetAllForOrg("LearningSpaces");
            return repos.ToList();
        }

        public static Repository GetRepo(string Name){
            return await client.Repository.Get("LearningSpaces",Name);
        }

        public static List<Commit> GetCommits(String Name){
            var commits = await client.Repository.Commits.GetAll("LearningSpaces",Name);
            return commits.ToList();
        }

        public static List<Commit> GetCommits(Repository repo){
            var commits = await client.Repository.Commits.GetAll(repo.Owner.Name,repo.Name);
            return commits.ToList();
        }
    }
}