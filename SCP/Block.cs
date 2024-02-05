namespace SCP
{
    public class Block
    {
        public string opcode { get; set; }
        public string next { get; set; }
        public string parent { get; set; }
        public object inputs { get; set; }
        public object fields { get; set; }
        public bool shadow { get; set; }
        public bool topLevel { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }
}
