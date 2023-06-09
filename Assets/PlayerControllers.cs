using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public PlayerAnimation playerAnimation;

    public float speed;

    private void Update()
    {
        InputMove();
        return;
    }

    private void InputMove()
    {
        this.playerAnimation.Setldle(true);
        this.playerAnimation.SetMoveX(0f);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
            this.playerAnimation.Setldle(false);
            this.playerAnimation.SetMoveX(-1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
            this.playerAnimation.Setldle(false);
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
