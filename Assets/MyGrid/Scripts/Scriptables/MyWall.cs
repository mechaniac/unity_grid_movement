using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyWall : ScriptableObject
{
    public string type; //Wall, ...
    public Color pixelColor;
    public GameObject myPrefab;
    public GameObject InstantiateUnit(int w, int h, Transform parent)
    {
        var p = Instantiate(myPrefab, new Vector3(w, .50f, h), Quaternion.identity);
        p.gameObject.transform.SetParent(parent);

        return p;
    }
}
