using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public float speed;

    private void Update()
    {
        Move();
        return;
    }

    private void Move()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime, Space.Self);
        return;
    }
}
