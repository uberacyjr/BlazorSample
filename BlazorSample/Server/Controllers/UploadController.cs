using BlazorSample.Converter.Models;
using BlazorSample.Converter.Services;
using BlazorSample.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BlazorSample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task Post(GenericFile file)
        {
            SaveFile(file);
            GetCsvData(file);
        }

        private static void GetCsvData(GenericFile file)
        {
            Stream stream = new MemoryStream(file.FileContent);
            var data = ConverterService.ToCsv<Foo>(new StreamReader(stream));
        }

        private void SaveFile(GenericFile file)
        {
            var path = $"{_env.ContentRootPath}\\files\\{file.Name}";
            var fs = System.IO.File.Create(path);
            fs.Write(file.FileContent, 0, file.FileContent.Length);
            fs.Close();
        }
    }
}