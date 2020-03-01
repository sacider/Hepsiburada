using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.Model
{
    public class GeneralModel
    {
        public int[] SizeRectangle { get;set;}
        public List<RoverModel> RoverModel { get; set; }
    }

    public class RoverModel
    {
        public string[] StartPoint { get; set; }
        public string Direction { get; set; }
    }

    public class Step
    {
        public string Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
