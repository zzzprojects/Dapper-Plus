using System.Collections.Generic;

namespace Z.Test
{
    public class SingleMany
    {
        public int ID { get; set; }

        public int ColumnInt { get; set; }

        public int ColumnUpdateInt { get; set; }

        public SingleMany Single1 { get; set; }
        public SingleMany Single2 { get; set; }
        public SingleMany Single3 { get; set; }

        public List<SingleMany> Many1 { get; set; }
        public List<SingleMany> Many2 { get; set; }
        public List<SingleMany> Many3 { get; set; }
    }
}