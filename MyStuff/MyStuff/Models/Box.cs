using System;
using SQLite;

namespace MyStuff
{
    public class Box
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public string Destination { get; set; }
    }
}
