using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject bullet;

    public float speed;

    private void Update()
    {
        FireShoot();
        Move();
        return;
    }

    private void FireShoot()
    {
        Instantiate(this.bullet, this.transform);
        return;
    }

    private void Move()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime, Space.Self);
        return;
    }
}
