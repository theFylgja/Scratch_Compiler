
namespace SCP
{
    public class Target
    {
        public bool isStage { get; set; }
        public string name { get; set; }
        public object variables { get; set; }
        public object lists { get; set; }
        public object broadcasts { get; set; }
        public object blocks { get; set; }
        public object comments { get; set; }
        public int currentCostume { get; set; }
        public Costume[] costumes { get; set; }
        public Sound[] sounds { get; set; }
        public int volume { get; set; }
        public int layerOrder { get; set; }
        public bool visible { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double size { get; set; }
        public double direction { get; set; }
        public bool draggable { get; set; }
        public string rotationStyle { get; set; }
        public int tempo { get; set; }
        public int videoTransparency { get; set; }
        public string videoState { get; set; }
        public object textToSpeechLanguage { get; set; }

        public Target(bool isStage, string name, VariableContainer variables, BroadcastContainer broadcasts, BlockContainer blocks, CommentContainer comments, int currentCostume, Costume[] costumes, Sound[] sounds, int volume, int layerOrder, bool visible, double x, double y, double size, double direction, bool draggable, string rotationStyle)
        {
            this.isStage = isStage;
            this.name = name;
            this.variables = variables;
            this.broadcasts = broadcasts;
            this.blocks = blocks;
            this.comments = comments;
            this.currentCostume = currentCostume;
            this.costumes = costumes;
            this.sounds = sounds;
            this.volume = volume;
            this.layerOrder = layerOrder;
            this.visible = visible;
            this.x = x;
            this.y = y;
            this.size = size;
            this.direction = direction;
            this.draggable = draggable;
            this.rotationStyle = rotationStyle;
        }
        public Target(string name, BlockContainer blocks)
        {
            this.isStage = false;
            this.name = name;
            this.variables = new object();
            this.lists = new object();
            this.broadcasts = new object();
            this.blocks = blocks;
            this.comments = new object();
            this.currentCostume = 0;
        }
    }

    public class Stage
    {
        public bool isStage { get; set; }
        public string name { get; set; }
        public object variables { get; set; }
        public object broadcasts { get; set; }
        public object blocks { get; set; }
        public object comments { get; set; }
        public int currentCostume { get; set; }
        public Costume[] costumes { get; set; }
        public Sound[] sounds { get; set; }
        public float volume { get; set; }
        public int layerOrder { get; set; }
        public int tempo { get; set; }
        public int videoTransparency { get; set; }
        public string videoState { get; set; }
        public object textToSpeechLanguage { get; set; }
    }
    public class Sprite
    {
        public bool isStage { get; set; }
        public string name { get; set; }
        public object variables { get; set; }
        public object broadcasts { get; set; }
        public BlockContainer blocks { get; set; }
        public object comments { get; set; }
        public int currentCostume { get; set; }
        public Costume[] costumes { get; set; }
        public Sound[] sounds { get; set; }
        public float volume { get; set; }
        public int layerOrder { get; set; }
        public bool visible { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double size { get; set; }
        public double direction { get; set; }
        public bool draggable { get; set; }
        public string rotationStyle { get; set; }
    }
}
