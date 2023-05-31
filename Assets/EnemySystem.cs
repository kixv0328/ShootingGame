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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        return;
    }
}
