﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhotoSauce.MagicScaler;
using Shop.BLL.Intefaces;
using System.Runtime.Serialization;

namespace Shop.BLL.Services
{
    public class FileService : IFileService
    {
        private string _imagePath;

        public FileService(IConfiguration config)
        {
            _imagePath = config["Path:Images"];

        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public bool RemoveImage(string image)
        {
            try
            {
                var file = Path.Combine(_imagePath, image);
                if (File.Exists(file))
                    File.Delete(file);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }

                //InternetExplorer Error
                //var fileName = image.FileName;
                var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    MagicImageProcessor.ProcessImage(image.OpenReadStream(), fileStream, ImageOptions());
                }

                return fileName;
            }
            catch (Exeption e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }
        }

        private ProcessImageSettings ImageOptions() => new ProcessImageSettings
        {
            Width = 800,
            Height = 500,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Jpeg,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420
        };
    }

    [Serializable]
    internal class Exeption : Exception
    {
        public Exeption()
        {
        }

        public Exeption(string message) : base(message)
        {
        }

        public Exeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Exeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
