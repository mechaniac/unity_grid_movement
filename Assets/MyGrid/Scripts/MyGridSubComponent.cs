using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGridNS
{

    [RequireComponent(typeof(MyGrid))]
    public class MyGridSubComponent : MonoBehaviour
    {
        protected MyGrid myGrid;

        public virtual void Awake()
        {
            myGrid = GetComponent<MyGrid>();
        }

        public bool HasGrid()
        {
            return myGrid != null;
        }
    }
}
