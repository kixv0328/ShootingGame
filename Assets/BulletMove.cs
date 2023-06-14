using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public float speed;
    public EffectGenerator effectGenerator;

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

     private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
        this.effectGenerator.DropEffect();
        return;
    }
}
