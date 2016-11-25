using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSystemViewer.Models;
using System.IO;

namespace FileSystemViewer.Controllers
{
    public class FileSystemController : ApiController
    {
        public MakeRequest request;
        public FileSystemController()
        {
            request = new MakeRequest();
        }
        //api/FileSystem/GetFilesWeights?path
        [HttpGet]
        public IEnumerable<string> GetDirectories(string path)
        {
            request.Path = path;
            List<string> dirs =  request.GetSubDrectories().Select(d => d.Name).ToList();
            return request.GetSubDrectories().Select(d => d.Name);
        }

        [HttpGet]
        public Dictionary<string, int> GetFilesWeights(string path)
        {
            request.Path = path;
            List<FileInfo> files = request.GetAllFiles();
            List<FileInfo> less10mb = new List<FileInfo>();
            List<FileInfo> from10to50mb = new List<FileInfo>();
            List<FileInfo> more100mb = new List<FileInfo>();

            Dictionary<string, int> res = new Dictionary<string, int>();

            request.FixedFilter(files, ref less10mb, ref from10to50mb, ref more100mb);
            res.Add("Less 10Mb", less10mb.Count);
            res.Add("10Mb-50Mb", from10to50mb.Count);
            res.Add("More 100Mb", more100mb.Count);

            return res;
        }

    }
}
