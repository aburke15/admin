using System;
using System.Collections.Generic;

namespace Admin.Data.Models
{
    public partial class FileResource
    {
        public Guid FileResourceId { get; set; }
        public string Filename { get; set; }
        public int Filesize { get; set; }
        public byte[] Content { get; set; }
    }
}
