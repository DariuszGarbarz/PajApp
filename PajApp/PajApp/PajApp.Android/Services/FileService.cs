using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PajApp.Droid.Services;
using PajApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace PajApp.Droid.Services
{
    public class FileService : IFileService
    {
        public async Task WriteTextAsync(string name, string content)
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filePath = System.IO.Path.Combine(basePath, name);
            using (var writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}