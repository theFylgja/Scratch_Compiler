namespace SCP
{
    public class JsonFile
    {
        public Target[] targets { get; set; }
        public Monitor[] monitors { get; set; }
        public object[] extensions { get; set; }
        public Meta meta { get; set; }
    }
}
