using System;
using SQLite;

namespace MyStuff
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemNotes { get; set; }
        public string BoxName { get; set; }
    }
}
