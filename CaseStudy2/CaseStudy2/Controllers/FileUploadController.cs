using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.IO.Compression;

namespace CaseStudy2.Controllers
{
    public class FileUploadController : ApiController
    {

        [HttpPost()]
        public string UploadFiles()
        {
            int iUploadedCnt = 0;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            string x = "Data";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/"+x+"/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        
                        hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }

                //string pathToZip = (sPath + "G7CaseStudy1-master.zip");
                //string destination = sPath+ "G7CaseStudy1-master";
                //Directory.CreateDirectory(sPath+ "G7CaseStudy1-master");
                //using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
                //{
                //    foreach (ZipArchiveEntry entry in archive.Entries)
                //    {
                //        entry.ExtractToFile(Path.Combine(destination, entry.FullName));
                //    }
                //}

                string startPath = sPath;
                string zipPath = sPath + Path.GetFileName(hpf.FileName);
                if (!File.Exists(sPath + Path.GetFileNameWithoutExtension(hpf.FileName)))
                {
                    string extractPath = sPath + Path.GetFileNameWithoutExtension(hpf.FileName);
                    ZipFile.ExtractToDirectory(zipPath, extractPath);

                }

                else
                    return "File Exists Please Change the File Name and try It again";
            }

            // RETURN A MESSAGE.
            System.Web.HttpPostedFile hpf1 = hfc[0];
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully" + Path.GetFileName(hpf1.FileName);
            }
            else
            {
                return "Upload Failed";
            }

        }
    }
}
