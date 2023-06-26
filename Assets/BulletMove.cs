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

        int t_ScreenY = Screen.height;
        int t_ScreenX = Screen.width;
        Vector2 t_Pos = Camera.main.ScreenToWorldPoint(new Vector3(t_ScreenX, t_ScreenY));

        Vector2 t_Min = t_Pos * -1f;
        Vector2 t_Max = t_Pos;
        Vector2 t_BullentPos = this.transform.position;

        if (t_Max.y < t_BullentPos.y)
        {
            Destroy(this.gameObject);
        }
        else if (t_Min.y > t_BullentPos.y)
        {
            Destroy(this.gameObject);
        }

        if (t_Max.x < t_BullentPos.x)
        {
            Destroy(this.gameObject);
        }
        else if (t_Min.x > t_BullentPos.x)
        {
            Destroy(this.gameObject);
        }

        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemySystem>() != null)
        {
            collision.GetComponent<EnemySystem>().CheckHp();
            collision.GetComponent<EnemySystem>().HitAction();
        }
        else if (collision.GetComponent<PlayerControllers>() != null)
        {
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);
        this.effectGenerator.DropEffect();
        return;
    }
}
