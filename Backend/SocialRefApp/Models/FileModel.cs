using System;
namespace SocialRefApp.Models
{
        public class FileModel
        {
            required public int Id { get; set; }
            required public string Name { get; set; }
            required public string FileType { get; set; }
            required public string Extension { get; set; }
            required public string Description { get; set; }
            required public string UploadedBy { get; set; }
            required public DateTime CreatedOn { get; set; }
        }
}

