using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGradeMove : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Move();
        return;
    }

    private void Move()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime, Space.Self);
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        collision.GetComponent<WeaponSystem>().GradeUp();
        return;
    }
}
