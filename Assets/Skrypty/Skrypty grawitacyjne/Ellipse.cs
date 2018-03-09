using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{
    public float osX;
    public float osY;

    public Ellipse (float osX, float osY)
    {
        this.osX = osX;
        this.osY = osY;
    }

    public Vector2 Evaluate(float t)
    {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle) * osX;
        float y = Mathf.Cos(angle) * osY;
        return new Vector2(x, y);
    }


}
