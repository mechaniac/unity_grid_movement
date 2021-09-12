using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGridNS;

public class Unit : MonoBehaviour
{

    public MyCell currentCell;
    public MyUnit type;
    public DIRECTION orientation;
    
    public int currentHealth;

    public void SetType(MyUnit type)
    {
        this.type = type;
        currentHealth = type.maxHealth;
    }

    public void MoveTo(MyCell cell)
    {
        transform.position = cell.position;
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }


    public IEnumerator ColorFlash(Color toColor)
    {
        var mR = GetComponent<MeshRenderer>();
        if (mR == null) yield break;
        //Debug.Log("colorFlahsing");
        Color fromColor = mR.material.color;

        float elapsedTime = 0f;
        float duration = .4f;

        while (elapsedTime < duration)
        {
            mR.material.color = Color.Lerp(mR.material.color, toColor, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mR.material.color = fromColor;
        yield return null;
    }

}
