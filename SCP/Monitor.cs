namespace SCP
{
    public class Monitor
    {
        public string id { get; set; }
        public string mode { get; set; }
        public string opcode { get; set; }
        public Params @params { get; set; }
        public string spriteName { get; set; }
        public float value { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public bool visible { get; set; }
        public float sliderMin { get; set; }
        public float sliderMax { get; set; }
        public bool isDiscrete { get; set; }

        public Monitor(string id, string mode, string opcode, Params @params, string spriteName, float value, float width, float height, float x, float y, bool visible, float sliderMin, float sliderMax, bool isDiscrete)
        {
            this.id = id;
            this.mode = mode;
            this.opcode = opcode;
            this.@params = @params;
            this.spriteName = spriteName;
            this.value = value;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.visible = visible;
            this.sliderMin = sliderMin;
            this.sliderMax = sliderMax;
            this.isDiscrete = isDiscrete;
        }
        public Monitor(string variableName, float value)
        {
            this.id = "variable_handle_moni-" + variableName;
            this.mode = "default";
            this.opcode = "data_variable";
            this.@params = new Params(variableName);
            this.spriteName = null;
            this.value = 0;
            this.width = 0;
            this.height = 0;
            this.x = 5;
            this.y = 5;
            this.visible = false;
            this.sliderMin = 0;
            this.sliderMax = 100;
            this.isDiscrete = true;
        }
        public Monitor()
        {
            this.id = null;
            this.mode = null;
            this.opcode = null;
            this.@params = null;
            this.spriteName = null;
            this.value = 0;
            this.width = 0;
            this.height = 0;
            this.x = 0;
            this.y = y;
            this.visible = false;
            this.sliderMin = 0;
            this.sliderMax = 100;
            this.isDiscrete = true;
        }
    }
    public class Params
    {
        public string VARIABLE { get; set; }

        public Params(string variableName)
        {
            this.VARIABLE = variableName;
        }
    }
}
