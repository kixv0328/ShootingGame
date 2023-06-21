using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMap : MonoBehaviour
{
    public float speed;

    public SpriteRenderer sR;

    private void Update()
    {
        Loop();
        return;
    }

    private void Loop()
    {
        Vector2 tempSize = new Vector2();
        tempSize.x = this.sR.size.x;
        tempSize.y = this.sR.size.y + Time.deltaTime * this.speed;

        if (tempSize.y > 24f)
        {
            tempSize.y = 12f;
        }

        this.sR.size = tempSize;
        return;
    }
}
