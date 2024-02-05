namespace SCP
{
    public class Meta
    {
        public string semver { get; set; }
        public string vm { get; set; }
        public string agent { get; set; }

        public Meta()
        {
            semver = "3.0.0";
            vm = "2.1.14";
            agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:120.0) Gecko/20100101 Firefox/120.0";
        }
    }
}
