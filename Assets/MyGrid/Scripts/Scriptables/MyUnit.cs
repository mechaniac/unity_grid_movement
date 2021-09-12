using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MyUnit : ScriptableObject
{
    public UnitType type; //Pawn, Knight, Bishop, Rook, ...
    //public FactionType faction;
    public Color pixelColor;
    public Color enemyPixelColor;
    public Unit unitPrefab; //the GameObject to be instantiated

    public int maxHealth;

    public Unit InstantiateUnit(int w, int h, Transform parent)
    {
        var p = Instantiate(unitPrefab, new Vector3(w, 0f, h), Quaternion.identity);
        p.gameObject.transform.SetParent(parent);
        p.SetType(this);
        return p;
    }

}

public enum UnitType
{
    none,
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn

}

public enum FactionType
{
    Player,
    Enemy
}
