using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public float speed;

    public ItemGradeMove itemGradeMove;
    public bool isDropItem;

    private void Update()
    {
        AutoMove();
        return;
    }

    private void AutoMove()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime, Space.Self);
        int t_ScreenY = Screen.height;
        int t_ScreenX = Screen.width;
        Vector2 t_Pos = Camera.main.ScreenToWorldPoint(new Vector3(t_ScreenX, t_ScreenY));
        t_Pos = t_Pos * 1.5f;

        Vector2 t_Min = t_Pos * -1f;
        Vector2 t_Max = t_Pos;
        Vector2 t_EnemyPos = this.transform.position;

        if (t_Max.x < t_EnemyPos.x)
        {
            Destroy(this.gameObject);
        }
        else if (t_Min.x > t_EnemyPos.x)
        {
            Destroy(this.gameObject);
        }

        if (t_Min.y > t_EnemyPos.y)
        {
            Destroy(this.gameObject);
        }
       
        return;
    }

    public void DropItem()
    {
        if (this.isDropItem)
        {
            Vector3 t_DropPos = this.transform.position;
            Instantiate(this.itemGradeMove, t_DropPos, Quaternion.identity);
        }
        return;
    }
}
