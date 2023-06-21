using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public PlayerAnimation playerAnimation;

    public BoxCollider2D boxCollider2D;

    public float speed;



    private void Update()
    {
        InputMove();
        Moveln();
        return;
    }

    private void Moveln()
    {
        Vector2 t_Min = this.boxCollider2D.bounds.min;
        Vector2 t_Max = this.boxCollider2D.bounds.max;
        Vector2 t_PlayerUnitPos = this.transform.position;

        if (t_Max.x < t_PlayerUnitPos.x)
        {
            t_PlayerUnitPos.x = t_Max.x;
        }
        else if (t_Min.x > t_PlayerUnitPos.x)
        {
            t_PlayerUnitPos.x = t_Min.x;
        }

        if (t_Max.y < t_PlayerUnitPos.y)
        {
            t_PlayerUnitPos.y = t_Max.y;
        }
        else if (t_Min.y > t_PlayerUnitPos.y)
        {
            t_PlayerUnitPos.y = t_Min.y;
        }

        this.transform.position = t_PlayerUnitPos;
        return;
    }

    private void InputMove()
    {
        this.playerAnimation.SetIdle(true);
        this.playerAnimation.SetMoveX(0f);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
            this.playerAnimation.SetIdle(false);
            this.playerAnimation.SetMoveX(-1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
            this.playerAnimation.SetIdle(false);
            this.playerAnimation.SetMoveX(+1f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        }

        return;
    }
}
