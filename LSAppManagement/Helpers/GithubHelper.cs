
using LSAppManagement.Models;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
namespace LSAppManagement.Helpers
{
    public static class GitHubHelper
    {
        private static string BaseUrl = @"https://api.github.com";
        private static NetworkCredential cred = new NetworkCredential("seabass992", "Seabass_992");
        private static string auth = Convert.ToBase64String(new ASCIIEncoding().GetBytes("seabass992:Seabass_992"));
        private static CredentialCache cache = new CredentialCache();

        public static UserModel GetOrg()
        {
            string Url = BaseUrl + @"/orgs/LearningSpaces";
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<UserModel> (Json);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<RepositoryModel> GetUserRepos(string UserName)
        {
            string Url = BaseUrl + @"orgs/LearningSpaces/repos";
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<RepositoryModel>>(Json);
                }
            }
            catch (Exception e)
            {
                return new List<RepositoryModel>();
            }
        }

        public static List<RepositoryModel> GetUserRepos(int UserId)
        {
            string Url = BaseUrl + @"/user/" + UserId + "/repos";
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<RepositoryModel>>(Json);
                }
            }
            catch (Exception e)
            {
                return new List<RepositoryModel>();
            }
        }

        public static List<RepositoryModel> GetOrgRepos(string OrgName)
        {
            string Url = BaseUrl + @"/orgs/" + OrgName + "/repos";
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<RepositoryModel>>(Json);
                }
            }
            catch (Exception e)
            {
                return new List<RepositoryModel>();
            }
        }

        public static List<RepositoryModel> GetOrgRepos(int OrgId)
        {
            string Url = BaseUrl + @"/organizations/" + OrgId + "/repos";
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<RepositoryModel>>(Json);
                }
            }
            catch (Exception e)
            {
                return new List<RepositoryModel>();
            }
        }

        public static bool IsAuthenticated()
        {
            return true;
        }
        public static RepositoryModel GetRepo(string Name)
        {
            string Url = BaseUrl + @"/repos/LearningSpaces/" + Name;
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Basic " + auth);
            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<RepositoryModel>(Json);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static RepositoryModel GetRepo(int Id)
        {
            string Url = BaseUrl + @"/repositories/" + Id;
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<RepositoryModel>(Json);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<CommitModel> GetCommits(RepositoryModel repo)
        {
            string Url = repo.Url + "/commits";
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Basic " + auth);

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    var foo = JsonConvert.DeserializeObject<List<CommitModel>>(Json);
                    return foo;
                }
            }
            catch (Exception e)
            {
                return new List<CommitModel>();
            }
        }

        public static List<CommitModel> GetCommits(string UserName, string RepoName)
        {
            string Url = BaseUrl + "/repos/" + UserName + "/" + RepoName + "/commits";

            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<CommitModel>>(Json);
                }
            }
            catch (Exception e)
            {
                return new List<CommitModel>();
            }
        }

        public static CommitModel GetCommit(RepositoryModel repo, string SHA1)
        {
            string Url = repo.Url + "/commits/" + SHA1;
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using(StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<CommitModel>(Json);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static CommitModel GetCommit(string OwnerName, string RepoName, string SHA1)
        {
            string Url = BaseUrl + "/repos/" + OwnerName + "/" + RepoName + "/commits/" + SHA1;
            if (cache.GetCredential(new Uri(BaseUrl), "Basic") == null)
            {
                cache.Add(new Uri(BaseUrl), "Basic", cred);
            }
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            request.UserAgent = "Seabass992";
            request.Accept = "application/json";
            request.Credentials = cache;
            request.PreAuthenticate = true;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string Json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<CommitModel>(Json);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}