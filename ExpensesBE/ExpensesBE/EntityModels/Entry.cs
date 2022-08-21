using System;
using System.Collections.Generic;

namespace ExpensesBE.EntityModels
{
    public partial class Entry
    {
        public long EntryId { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double Value { get; set; }
    }
    public partial class Entryinsert
    {
        public long EntryId { get; set; }
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double Value { get; set; }
    }
}
