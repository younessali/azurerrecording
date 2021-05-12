using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using pocblobStorage.Models;
using pocblobStorage.Services;

namespace pocblobStorage.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IConfiguration _configuration;
        string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=prxpoc;AccountKey=6hNYl0D0FSZOTqatCprj0xQIwtqioJZPW6CmJKr74R7/PlkcvGTQcszBQxq/KkyFnomBHE3XH4YHSXGAPnIdTg==;EndpointSuffix=core.windows.net";
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// list of videos from blobstorage 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ShowAllBlobs()
        {
        
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("videos");
            CloudBlobDirectory dirb = container.GetDirectoryReference("videos");
            List<FileData> fileList = new List<FileData>();
          
             
                BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(string.Empty,
                true, BlobListingDetails.Metadata, 100, null, null, null);
                foreach (var blobItem in resultSegment.Results)
                {
                    // A flat listing operation returns only blobs, not virtual directories.
                    var blob = (CloudBlob)blobItem;
                    fileList.Add(new FileData()
                    {
                        FileName = blob.Name,
                        FileSize = Math.Round((blob.Properties.Length / 1024f) / 1024f, 2).ToString(),
                        ModifiedOn = DateTime.Parse(blob.Properties.LastModified.ToString()).ToLocalTime().ToString()
                    });
                }
          
            return View(fileList);
        }
       /// <summary>
       /// download files from blobstorage
       /// </summary>
       /// <param name="blobName"></param>
       /// <returns></returns>

        public async Task<IActionResult> Download(string blobName)
        {
            CloudBlockBlob blockBlob;
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("videos");
                blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);

                var blobRequestOptions = new BlobRequestOptions
                {
                    ServerTimeout = TimeSpan.FromSeconds(30),
                    MaximumExecutionTime = TimeSpan.FromSeconds(120),
                    RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(3), 3),
                };

                var shareAccessSig = blockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy() {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime =DateTime.Now.AddHours(12)

                });
                var videoUrlTobePlayed = string.Format("{0}{1}", blockBlob.Uri, shareAccessSig);
                ViewData["Video"] = videoUrlTobePlayed;
                await blockBlob.DownloadToStreamAsync(memoryStream, null, blobRequestOptions,null);
            }
      
            Stream blobStream = blockBlob.OpenReadAsync().Result;
            return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);
        }
        /// <summary>
        /// Delete blob storage file 
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(string blobName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = "videos";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
          
            var blob = cloudBlobContainer.GetBlobReference(blobName);
            await blob.DeleteIfExistsAsync();
            return RedirectToAction("ShowAllBlobs", "Home");
        }

        /// <summary>
        /// upload large file 
        /// </summary>
        /// <param name="fileSelect"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        public IActionResult Post(IFormFile fileSelect)
        {
        
            if (fileSelect == null || fileSelect.Length == 0)
                return View("No file selected for upload.");
            string systemFileName = fileSelect.FileName;
          
                byte[] fileData = new byte[fileSelect.Length];
                BlobStorageService objBlobService = new BlobStorageService();
                var filePath = objBlobService.UploadFileToBlob(systemFileName, fileData, fileSelect.ContentType);
              
                TempData["uploadedUri"] = filePath;
               
            
            if (string.IsNullOrEmpty(filePath))
                return View("UploadSuccess");
            else
                return View("UploadError");

        }
        public IActionResult UploadVideo()
        {
            return View("UploadVideo");
        }

        public IActionResult Video(string blobName)
        {
            CloudBlockBlob blockBlob;
            using (MemoryStream memoryStream = new MemoryStream())
            {
             
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("videos");
                blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
                var shareAccessSig = blockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.Now.AddHours(12)

                });
                var videoUrlTobePlayed = string.Format("{0}{1}", blockBlob.Uri, shareAccessSig);
                ViewData["Video"] = videoUrlTobePlayed;
             
            }
            return View("VideoPlayer");
        }

        

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
public class FileData
{
    public string FileName { get; set; }
    public string FileSize { get; set; }
    public string ModifiedOn { get; set; }
}



