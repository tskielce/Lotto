using System;
using System.Collections.Generic;

namespace Data
{
    public class DataSchema
    {
        public int id { get; set; }
        public DateTime LottoDate { get; set; }
        public List<int> numbers { get; set; }
    }
}
