using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MyTest
{
    public class TestDownloadPic
    {
        public static void TestStart()
        {
            var picList = new List<string> {
                "https://img1.doubanio.com/view/photo/s_ratio_poster/public/p2566598269.webp",
                "https://img3.doubanio.com/view/photo/s_ratio_poster/public/p2567841004.webp"
            };

            // I:\\OnGIt\\CSharpOnGit\\MyCSharpProj\\Test201907
            var programPath = Environment.CurrentDirectory;
            foreach(var urlInfo in picList.Select((n, i) => new {value = n, index = i}))
            {                
                var fileName = Path.GetFileName(urlInfo.value);
                var fileFullPath = Path.Combine(Environment.CurrentDirectory, "Pics", fileName);
                //Path.Combine(programPath, "Pics", urlInfo.index.ToString()) + "." + mid[mid.Length-1];
                DownloadPic(urlInfo.value, fileFullPath);
            }
        }

        /// <summary>
        /// 检测文件状态
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        public static bool CheckFileStatus(string fileFullPath)
        {
            var filePath = Path.GetDirectoryName(fileFullPath);
            // 检测目录是否存在
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (Directory.Exists(fileFullPath))
            {
                Directory.Delete(fileFullPath);
            }
            
            return true;
        }



        public static void DownloadPic(string uri, string fileFullPath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 检查远端文件是否存在
            // 检查ContentType是否包含Image,以防止response.StatusCode为OK时,文件不存在
            if ((response.StatusCode == HttpStatusCode.OK || 
                response.StatusCode == HttpStatusCode.Moved || 
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                // 检测本地文件目录以及文件
                if (CheckFileStatus(fileFullPath))
                {
                    using (Stream inputStream = response.GetResponseStream())
                    {
                        using (Stream outputStream = File.OpenWrite(fileFullPath))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            do
                            {
                                bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                                outputStream.Write(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                        }
                    }
                }
            }
            else
                throw new DirectoryNotFoundException($"{fileFullPath} 存在异常"); 
        }
    }
}