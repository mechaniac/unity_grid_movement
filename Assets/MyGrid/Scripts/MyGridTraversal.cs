using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGridNS
{
    
    public class MyGridTraversal : MyGridSubComponent
    {

        public List<MyCell> currentAvailableMoves;

        public override void Awake()
        {
            base.Awake();
        }


        List<MyCell> WalkLine(int w, int h, DIRECTION d)
        {
            var l = new List<MyCell>();

            return l;
        }

        public List<MyCell> GetAvailableMoves(Unit u)
        {
            var c = new List<MyCell>();
            if(u.type.type == UnitType.Queen)
            {
                //Debug.Log("Display Queen Move");
                foreach(DIRECTION direction in Enum.GetValues(typeof(DIRECTION)))
                {
                    c.AddRange(GetPath((int)u.currentCell.position.x, (int)u.currentCell.position.z, direction));
                }
                
            }

            if(u.type.type == UnitType.Pawn)
            {
                //Debug.Log("Display Pawn Move");
                c.AddRange(GetPath((int)u.currentCell.position.x, (int)u.currentCell.position.z,u.orientation));
            }
            currentAvailableMoves = c;
            return c;
        }


        List<MyCell> GetPath(int w, int h, DIRECTION d)
        {
            var l = new List<MyCell>();
            while (MakeStep()) { l.Add(myGrid.cells[w, h]); }


            bool MakeStep()
            {
                (int sW, int sH) = StepOneTile(w, h, d);
                if (!myGrid.DoesCellExist((sW, sH)) || myGrid.cells[sW, sH].isWall)
                {
                    return false;
                }
                (w, h) = StepOneTile(w, h, d);

                if(myGrid.cells[sW,sH].occupant != null)    //if path is blocked by unit
                {
                    l.Add(myGrid.cells[sW, sH]);    //Add attackable Unit to path...
                    return false;                   // ...and Stop!
                }
                return true;
            }

            return l;
        }

        (int w, int h) StepOneTile(int w, int h, DIRECTION d)
        {
            switch (d)
            {
                case DIRECTION.UP:
                    return (w, h + 1);
                case DIRECTION.UPLEFT:
                    return (w - 1, h + 1);
                case DIRECTION.LEFT:
                    return (w - 1, h);
                case DIRECTION.DOWNLEFT:
                    return (w - 1, h - 1);
                case DIRECTION.DOWN:
                    return (w, h - 1);
                case DIRECTION.DOWNRIGHT:
                    return (w + 1, h - 1);
                case DIRECTION.RIGHT:
                    return (w + 1, h);
                case DIRECTION.UPRIGHT:
                    return (w + 1, h + 1);
            }
            return (w, h);
        }
    }

    public enum DIRECTION
    {
        UP,
        UPLEFT,
        LEFT,
        DOWNLEFT,
        DOWN,
        DOWNRIGHT,
        RIGHT,
        UPRIGHT
    }
}