using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGridNS
{

    public class MyGridFromPSDFile : MyGridSubComponent
    {
        public MapColors mapColors;
        public Texture2D jpgMap;

        public MyUnit[] availableUnits;

        public MyWall[] availableWalls;

        public override void Awake()
        {
            base.Awake();
        }

        public void SetGridFromPSD(MyGrid g)
        {
            (g.width, g.height) = (jpgMap.width, jpgMap.height);
            g.cells = GenerateCells();
        }


        internal MyCell[,] GenerateCells()
        {

            var cells = new MyCell[jpgMap.width, jpgMap.height];

            for (int w = 0; w < jpgMap.width; w++)
            {
                for (int h = 0; h < jpgMap.height; h++)
                {
                    cells[w, h] = new MyCell(new Vector3(w, 0, h), false);

                    Color pixelColor = jpgMap.GetPixel(w, h);
                    cells[w, h].isWall = false;
                    foreach (var wall in availableWalls)
                    {
                        if (pixelColor.IsEqualTo(wall.pixelColor, .1f))
                        {
                            cells[w, h].isWall = true;
                            cells[w, h].wallType = wall;
                        }
                    }

                    foreach (var unit in availableUnits)
                    {
                        if (pixelColor.IsEqualTo(unit.pixelColor, .1f))
                        {
                            cells[w, h].occupantType = unit;
                            cells[w, h].faction = FactionType.Player;
                            //Debug.Log($"occupantType = {unit}");
                        }
                        if(pixelColor.IsEqualTo(unit.enemyPixelColor, .1f))
                        {
                            cells[w, h].occupantType = unit;
                            cells[w, h].faction = FactionType.Enemy;
                        }
                    }
                }
            }

            return cells;
        }



        //void SetCells()
        //{
            

        //    GameObject walls = new GameObject("walls");
        //    walls.transform.SetParent(transform);

        //    GameObject blackTiles = new GameObject("blackTiles");
        //    blackTiles.transform.SetParent(transform);

        //    for (int w = 0; w < width; w++)
        //    {
        //        for (int h = 0; h < height; h++)
        //        {
        //            cells[w, h] = new MyCell(new Vector3(w, 0, h), true);
        //            float g = jpgMap.GetPixel(w, h).grayscale;

        //            Color pixelColor = jpgMap.GetPixel(w, h);
        //            var l = Instantiate(labelPrefab, new Vector3(w, .2f, h), Quaternion.Euler(90, 0, 0));
        //            l.transform.SetParent(bgMap.transform);
        //            var t = l.GetComponentInChildren<Text>();
        //            t.text = $"{w}, {h} \n {g}";


        //            if (pixelColor.IsEqualTo(mapColors.wallColor, .1f))
        //            {
        //                var p = Instantiate(wallPrefab, new Vector3(w, .5f, h), Quaternion.identity);
        //                p.gameObject.transform.SetParent(walls.transform);
        //                cells[w, h].walkable = false;

        //            }
        //            if ((w + h) % 2 == 0 && g != 0)
        //            {
        //                var bT = Instantiate(blackTile, new Vector3(w, .05f, h), Quaternion.Euler(90, 0, 0));
        //                bT.gameObject.transform.SetParent(blackTiles.transform);
        //            }

        //            if (pixelColor.IsEqualTo(mapColors.playerColor, .1f))
        //            {
        //                Instantiate(playerPrefab, new Vector3(w, 0, h), Quaternion.identity);
        //                gridInterface.SetCanvasPosition(new Vector3(w, 0, h));
        //            }

        //            if (pixelColor.IsEqualTo(mapColors.enemieColor, .1f))
        //            {
        //                Instantiate(enemyPrefab, new Vector3(w, 0, h), Quaternion.identity);

        //            }

        //        }
        //    }
        //}



        
    }
    static class Extension
    {
        public static bool IsEqualTo(this Color me, Color other, float margin)
        {
            bool bR = CompareFloatWithMargin(me.r, other.r, margin);
            bool bG = CompareFloatWithMargin(me.g, other.g, margin);
            bool bB = CompareFloatWithMargin(me.b, other.b, margin);

            return bR && bG && bB;
        }
        static bool CompareFloatWithMargin(float f1, float f2, float m)
        {
            bool b1 = (f1 + m) > f2;
            bool b2 = (f1 - m) < f2;

            return b1 && b2;
        }
    }
}
