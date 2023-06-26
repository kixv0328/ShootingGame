using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [Header("체력")]
    public int hp;

    [Header("이동속도")]
    public float speed;

    [Header("아이템")]
    public ItemGradeMove itemGradeMove;
    public bool isDropItem;

    [Header("이미지 컴포넌트")]
    public SpriteRenderer spriteRenderer;

    [Header("원본 이미지")]
    public Sprite orginSkin;

    [Header("피격 이미지")]
    public Sprite hitSkin;

    [Header("피격 딜레이")]
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
        //1. 공격을 받았다
        //2. 피격 이미지로 변경한다
        this.spriteRenderer.sprite = this.hitSkin;
        //3. 일정 시간 뒤...<-
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
