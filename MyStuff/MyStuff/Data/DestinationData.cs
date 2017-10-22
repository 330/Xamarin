using System;
using System.Collections.Generic;

namespace MyStuff.Data
{
    public class DestinationData
    {
        private DestinationRoom room;
        List<string> roomList;
        public DestinationData()
        {
            room = new DestinationRoom();
            roomList = new List<string>();
            AddRoom();
        }

        private void AddRoom() {
            roomList.Add("Living Room");
            roomList.Add("Kitchen");
            roomList.Add("Bed Room");
            roomList.Add("Basement");
            roomList.Add("Bathroom");
            roomList.Add("Study Room");
            roomList.Add("Others");
        }

        private List<string> ToList() {
            return roomList;
        }
    }
}
