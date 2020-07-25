using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Utils
{
    public class UploadUtil
    {
        public Uploader DoFileUploading(string path, IFormFile file)
        {
            string fileName = "";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (file.Length > 0)
            {
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(path, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return new Uploader() { fileName = fileName, message = "Upload success" };
        }
        public class Uploader
        {
            public string fileName { get; set; }
            public string locationPath { get; set; }
            public string message { get; set; }
        }
    }
}
