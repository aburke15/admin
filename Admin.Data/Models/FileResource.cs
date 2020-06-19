using System;
using System.Collections.Generic;

namespace Admin.Data.Models
{
    public class FileResource : Entity
    {
        public string Filename { get; set; }
        public int Filesize { get; set; }
        public byte[] Content { get; set; }
        public FileResourceType Type { get; set; }
    }
}
