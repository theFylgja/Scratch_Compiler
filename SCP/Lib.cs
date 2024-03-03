using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace SCP
{
    public class Costume
    {
        public string name { get; set; }
        public int bitmapResolution { get; set; }
        public string dataFormat { get; set; }
        public string assetId { get; set; }
        public string md5ext { get; set; }
        public int rotationCenterX { get; set; }
        public int rotationCenterY { get; set; }
        private Random random = new Random();

        public Costume(string name, int bitmapResolution, string dataFormat, string assetId, int rotationCenterX, int rotationCenterY)
        {
            this.name = name;
            this.bitmapResolution = bitmapResolution;
            this.dataFormat = dataFormat;
            this.assetId = assetId;
            this.md5ext = assetId + "." + dataFormat;
            this.rotationCenterX = rotationCenterX;
            this.rotationCenterY = rotationCenterY;
        }
        public Costume(string name, int bitmapResolution, string dataFormat, int rotationCenterX, int rotationCenterY)
        {
            this.name = name;
            this.bitmapResolution = bitmapResolution;
            this.dataFormat = dataFormat;
            this.assetId = "waltuh";
            this.md5ext = assetId + "." + dataFormat;
            this.rotationCenterX = rotationCenterX;
            this.rotationCenterY = rotationCenterY;
        }
        public Costume(string fileName, string rootFolder)
        {
            this.name = fileName.Substring(0, fileName.Length - 4);
            this.bitmapResolution = 2;
            this.dataFormat = fileName.Substring(fileName.Length - 3);
            this.assetId = CreateAssetID(rootFolder + @"\" + fileName);
            this.md5ext = assetId + "." + dataFormat;
            this.rotationCenterX = 0;
            this.rotationCenterY = 0;
        }
        private string CreateAssetID(string filePath)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = File.ReadAllBytes(filePath);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmpHash.Length; i++)
            {
                sb.Append(tmpHash[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }

    public class Sound
    {
        public string name { get; set; }
        public string assetId { get; set; }
        public string dataFormat { get; set; }
        public string format { get; set; }
        public int rate { get; set; }
        public int sampleCount { get; set; }
        public string md5ext { get; set; }

        public Sound(string name, string assetId, string dataFormat, string format, int rate, int sampleCount)
        {
            this.name = name;
            this.assetId = assetId;
            this.dataFormat = dataFormat;
            this.format = format;
            this.rate = rate;
            this.sampleCount = sampleCount;
            this.md5ext = assetId + "." + dataFormat;
        }
    }
}
