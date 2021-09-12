using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGridNS
{
    public class MyCell
    {
        public Vector3 position;
        public MyUnit occupantType;
        public FactionType faction;
        public Unit occupant;
        public bool isWall;
        public MyWall wallType;

        public bool IsInWalkableSet;
        public MyCell(Vector3 position, bool walkable)
        {
            this.position = position;
            isWall = walkable;
            occupantType = null;
            
            wallType = null;
            IsInWalkableSet = false;
        }

        public bool IsWalkable()
        {
            if(isWall == false && occupant == null) { return true; };
            return false;
        }
    }

}