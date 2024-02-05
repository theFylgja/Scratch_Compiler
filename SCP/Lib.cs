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
