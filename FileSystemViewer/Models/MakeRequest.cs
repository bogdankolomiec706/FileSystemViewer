using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemViewer.Models
{
    public class MakeRequest
    {
        string path;
        public string Path
        {
            get{ return path; }
            set{
                path = value;
                Directory = new DirectoryInfo(path);
            }
        }
        public DirectoryInfo Directory { get; set; }

        public MakeRequest(string pathVal = @"C:\")
        {
            path = pathVal;
            Directory = new DirectoryInfo(path);
        }

        public List<DirectoryInfo> GetSubDrectories()
        {
            return Directory.GetDirectories().ToList();
        }
        public List<FileInfo> GetAllFiles()
        {
            return Directory.GetFiles().ToList();
        }
        public List<FileInfo> FilterFies(List<FileInfo> files, long minW, long maxW)
        {
            return files.Where(f => f.Length >= minW && f.Length <= maxW).ToList();
        }

        ///<summary>
        ///We have to use 'ref' insted of 'out' modifier because some of them may not be used as it is possible 
        ///that in directory will be no files in chosen weight range
        ///</summary>
        public void FixedFilter(List<FileInfo> files, ref List<FileInfo> less10mb, ref List<FileInfo> from10to50mb, ref List<FileInfo> more100mb)
        {
            foreach (FileInfo file in files)
            {
                long L = file.Length;
                if (L < 10e6)
                    less10mb.Add(file);
                else if (L >= 10e6 && L <= 50e6)
                    from10to50mb.Add(file);
                else if (L > 100e6)
                    more100mb.Add(file);
            }
        }
    }
}
