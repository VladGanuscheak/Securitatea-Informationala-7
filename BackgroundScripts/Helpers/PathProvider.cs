using BackgroundScripts.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackgroundScripts.Helpers
{
    public class PathProvider : IPathProvider
    {
        private IHostingEnvironment _hostingEnvironment;

        public PathProvider(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public string MapPath(string path)
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath.Split($"//_hostingEnvironment.ApplicationName")[0], path);

            return filePath;
        }
    }
}
