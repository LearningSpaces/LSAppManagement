using LSAppManagement.Helpers;
using LSAppManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LSAppManagement.Models
{
    public class ApplicationModel
    {
        private class ValidateFileNameAttribute : ValidationAttribute
        {
            public override bool IsValid(object o)
            {
                Regex InvalidFileCharRegex = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");
                string filename = o as string;

                if(filename == null)
                {
                    return false;
                }
                if (InvalidFileCharRegex.IsMatch(filename))
                {
                    return false;
                }

                return true;
            }
        }
        public Uri Github
        {
            get
            {
                return new Uri("https://api.github.com/repos/LearningSpaces/" + GithubRepository);
            }
        }
        [Required]
        public string GithubRepository { get; set; }
        [Required]
        public string WebappPath { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ValidateFileName]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public CommitModel CurrentCommit { get; set; }

        public static explicit operator ApplicationModel(ApplicationEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            ApplicationModel app = new ApplicationModel()
            {
                Name = entity.Name,
                Description = entity.Description,
                ID = entity.ID,
                ProjectName = entity.ProjectName,
                WebappPath = entity.WebappPath,
                GithubRepository = entity.GithubRepository,
                Deleted = entity.Deleted,
                CurrentCommit = GitHubHelper.GetCommit("LearningSpaces", entity.GithubRepository, entity.CurrentCommit)
            };
            return app;
        }
    }
}