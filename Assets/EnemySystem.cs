using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("ü��")]
    public int hp;

    [Header("�̵��ӵ�")]
    public float speed;

    [Header("������")]
    public ItemGradeMove itemGradeMove;
    public bool isDropItem;

    [Header("�̹��� ������Ʈ")]
    public SpriteRenderer spriteRenderer;

    [Header("���� �̹���")]
    public Sprite orginSkin;

    [Header("�ǰ� �̹���")]
    public Sprite hitSkin;

    [Header("�ǰ� ������")]
    public float curHitDelay;
    public float maxHitDelay;

    private void Update()
    {
        AutoMove();
        UpdateHitDelay();
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

    public void CheckHp()
    {
        this.hp = this.hp - 1;
        if (this.hp <= 0)
        {
            Destroy(this.gameObject);
            DropItem();
        }
        return;
    }

    public void HitAction()
    {
        //1. ������ �޾Ҵ�
        //2. �ǰ� �̹����� �����Ѵ�
        this.spriteRenderer.sprite = this.hitSkin;
        //3. ���� �ð� ��...<-
        this.curHitDelay = this.maxHitDelay;
        return;
    }

    public void UpdateHitDelay()
    {
        if (this.curHitDelay < 0f)
        {
            this.spriteRenderer.sprite = this.orginSkin;
        }
        else
        {
            this.curHitDelay = this.curHitDelay - Time.deltaTime * 1f;
        }

        return;
    }
}
