using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.FileSetting
{
    public static class FileSettings
    {
        public const string ImagesPath = "/images";
        public const string AllowedExtensions = ".jpg,.jpeg,.png,.PNG,.webp,.gif";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
