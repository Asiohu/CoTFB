using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoTFBWebRole.Service
{
    public class BlobStorageService
    {
        public CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storage = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("ImageStore")); //Connect to connecting string
            CloudBlobClient blobClient = storage.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("andreasstorage0175"); //looking for a container by the specified name 
            if(blobContainer.CreateIfNotExists())  //if that continer dont exist 
            {
   
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off }); 
            }
            return blobContainer; //return container
        }
    }

 
}