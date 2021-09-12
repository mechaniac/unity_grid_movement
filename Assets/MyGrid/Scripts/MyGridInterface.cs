using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyGridNS
{
    [RequireComponent(typeof(Canvas))]
    public class MyGridInterface : MonoBehaviour
    {
        Canvas walkCanvas;
        public Image cursorPrefab;

        public Image dotPrefab;
        Image[] dotPool;
        int currentPoolDot;
        public Canvas labelPrefab;

        Image cursor;


        private void Awake()
        {
            CreateDotPool();
            InitializeCursor();
        }


        void CreateDotPool()
        {
            currentPoolDot = 0;
            dotPool = new Image[50];
            for (int i = 0; i < dotPool.Length; i++)
            {
                dotPool[i] = Instantiate(dotPrefab, new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 0));
                dotPool[i].transform.SetParent(this.transform);
                dotPool[i].gameObject.SetActive(false);
            }
            walkCanvas = GetComponent<Canvas>();
        }

        // CURSOR
        void InitializeCursor()
        {
            cursor = Instantiate(cursorPrefab, new Vector3(0, 1f, 0), Quaternion.Euler(90, 0, 0));
            cursor.transform.SetParent(this.transform);
        }

        public void OffsetCursor(Vector3 offset)
        {
            cursor.transform.position += offset;
        }
        public Vector3 GetCursorPosition()
        {
            return new Vector3((int)cursor.transform.position.x, 0, (int)cursor.transform.position.z);
        }
        // ---------


        public void SetDotsOnCells(List<MyCell> l)
        {
            ClearAllDots();
            foreach (var cell in l)
            {
                SetDot(cell.position);
            }
        }

        public void SetDot(Vector3 position)
        {
            dotPool[currentPoolDot].transform.position = position + new Vector3(0, .1f, 0);
            dotPool[currentPoolDot].gameObject.SetActive(true);
            currentPoolDot++;
        }
        public void ClearAllDots()
        {
            foreach (var dot in dotPool)
            {
                dot.gameObject.SetActive(false);
            }
            currentPoolDot = 0;
        }
        public void SetCanvasPosition(Vector3 position)
        {
            transform.position = position;
        }

        void SetTileInterface(int w, int h)
        {
            var l = Instantiate(labelPrefab, new Vector3(w, .2f, h), Quaternion.Euler(90, 0, 0));
            var t = l.GetComponentInChildren<Text>();
            t.text = $"{w}, {h}";
        }
    }
}
