using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System;

namespace MyGridNS
{
    public class MyGrid : MonoBehaviour
    {
        MyGridFromPSDFile myGridFromPSDFile;
        public MyGridTraversal myGridTraversal;

        public MyGridInterface myGridInterface;

        public Material mapMaterial;
        public Material enemyMaterial;

        GameObject bgMap;

        public Transform blackTile;


        GameObject walls;



        public int width;
        public int height;
        public MyCell[,] cells;

        public List<List<Unit>> units;


        private void Awake()
        {
            units = new List<List<Unit>>();
            units.Add(new List<Unit>());
            units.Add(new List<Unit>());

            myGridFromPSDFile = GetComponent<MyGridFromPSDFile>();
            myGridTraversal = GetComponent<MyGridTraversal>();


        }
        public List<MyCell> DisplayMove(Unit u)
        {
            //Debug.Log("displamove" + u);
            List<MyCell> l = myGridTraversal.GetAvailableMoves(u);
            
            myGridInterface.SetDotsOnCells(l);
            return l;
        }

        public void InitiializeGame()
        {
            SetCellsFromPSDComponent();
            GenerateGroundPlane(width, height);
            GenerateGameBoard(cells);
        }

        private void Start()
        {

        }

        internal bool DoesCellExist((int w, int h) c)
        {
            return c.w >= 0 && c.w < width && c.h >= 0 && c.h < height;
        }
        void SetCellsFromPSDComponent()
        {
            if (myGridFromPSDFile == null)
            {
                throw new System.Exception("no MyGridFromPSDFile Component attached");
            }
            myGridFromPSDFile.SetGridFromPSD(this);
        }

        void GenerateGroundPlane(int width, int height)
        {
            Vector3[] vertices = { new Vector3(0f, 0f, 0f), new Vector3(width, 0f, 0f), new Vector3(0f, 0f, height), new Vector3(width, 0f, height) };
            int[] triangles = { 0, 3, 1, 0, 2, 3 };
            Vector2[] uvs = { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };


            bgMap = new GameObject();
            bgMap.gameObject.transform.SetParent(gameObject.transform);
            bgMap.gameObject.transform.position = new Vector3(-.5f, 0, -.5f);
            bgMap.name = "groundPlane";
            var meshRenderer = bgMap.AddComponent<MeshRenderer>();
            meshRenderer.material = mapMaterial;
            //meshRenderer.material.SetTexture("_MainTex", jpgMap);
            var mesh = bgMap.AddComponent<MeshFilter>().mesh;

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.RecalculateNormals();
        }


        void GenerateGameBoard(MyCell[,] c)
        {
            GameObject wallParent = new GameObject("walls");
            wallParent.transform.SetParent(transform);

            GameObject blackTiles = new GameObject("blackTiles");
            blackTiles.transform.SetParent(transform);

            GameObject unitParent = new GameObject("units");
            unitParent.transform.SetParent(transform);

            for (int w = 0; w < c.GetLength(0); w++)
            {
                for (int h = 0; h < c.GetLength(1); h++)
                {


                    if ((w + h) % 2 == 0)
                    {
                        var bT = Instantiate(blackTile, new Vector3(w, .05f, h), Quaternion.Euler(90, 0, 0));
                        bT.gameObject.transform.SetParent(blackTiles.transform);
                    }

                    if (cells[w, h].wallType != null)
                    {
                        cells[w, h].wallType.InstantiateUnit(w, h, wallParent.transform);
                    }

                    if (cells[w, h].occupantType != null)
                    {
                        Unit u = cells[w, h].occupantType.InstantiateUnit(w, h, unitParent.transform);
                        u.currentCell = cells[w, h];
                        MyCell cel = cells[w, h];
                        //Debug.Log($"added: {cells[w, h].occupantType}");
                        
                        if(cel.faction == FactionType.Player)
                        {
                            units[0].Add(u);
                            cel.occupant = u;
                            Debug.Log($"added: {cel.occupantType}");
                        }

                        if (cel.faction == FactionType.Enemy)
                        {
                            cel.occupant = u;
                            units[1].Add(u);
                            u.GetComponent<MeshRenderer>().material = enemyMaterial;
                        }

                        if(cel.occupantType.type == UnitType.Pawn)
                        {
                            u.orientation = DIRECTION.UP;
                            if (cel.faction == FactionType.Enemy)
                            {
                                u.orientation = DIRECTION.DOWN;
                                u.transform.rotation = Quaternion.Euler(0, 180, 0);
                                
                            }
                        }
                        
                    }

                }
            }
        }

        internal void RemoveUnit(Unit b)
        {
            foreach (var l in units)
            {
                if (l.Contains(b))
                {
                    l.Remove(b);
                    Debug.Log("removed");
                }
            }
            Debug.Log("unit :  " + b);
            b.transform.position += new Vector3(0, 0.5f, 0);
            Destroy(b.gameObject);
        }

        void SetWalls()
        {
            walls = new GameObject("walls");
            walls.transform.parent = transform;
        }
        void ActivateInterfaceCells(List<MyCell> cells)
        {
            myGridInterface.ClearAllDots();
            myGridInterface.SetDotsOnCells(cells);
        }

    }




}