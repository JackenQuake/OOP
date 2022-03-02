using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary {
    
    public class Building {
        private readonly int _id;
        private int _height;
        private int _floors;
        private int _rooms;
        private int _porches;
        private static int counter = 0;

        public override int GetHashCode() => id;

        public int id { get => _id; }

        public int height {
            get => _height;
            set { _height = value; }
        }

        public int floors {
            get => _floors;
            set { _floors = value; }
        }

        public int rooms {
            get => _rooms;
            set { _rooms = value; }
        }

        public int porches {
            get => _porches;
            set { _porches = value; }
        }

        public int FloorHeight () => (height / floors);

        public int RoomsPerPorch() => (rooms / porches);

        public int RoomsPerFloor() => (rooms / floors);

        internal Building(int id, int height, int floors, int rooms, int porches) {
            _id = id;
            _height = height;
            _floors = floors;
            _rooms = rooms;
            _porches = porches;
            counter = id;
        }

        internal Building(int id) : this(id, 0, 0, 0, 0) { }

        internal Building() : this(counter + 1) { }
    }

    public class Creator {
        private static HashSet<Building> buildings = new HashSet<Building>();

        public static Building CreateBuild(int id, int height, int floors, int rooms, int porches) {
            var building = new Building(id, height, floors, rooms, porches);
            buildings.Add(building);
            return building;
        }

        public static Building CreateBuild(int id) {
            var building = new Building(id);
            buildings.Add(building);
            return building;
        }
        
        public static Building CreateBuild() {
            var building = new Building();
            buildings.Add(building);
            return building;
        }

        private Creator() { }

        public static Building GetByID(int id) {
            foreach (Building b in buildings) if (b.id == id) return b;
            return null;
        }

        public static void DeleteById(int id) {
            buildings.Remove(GetByID(id));
        }

        public static HashSet<Building> BuildingsList() => buildings;
    }
}
