using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        AutoMove();
        return;
    }

    private void AutoMove()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime, Space.Self);

        return;
    }
}
