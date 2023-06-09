using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public void SetMoveX(float value)
    {
        this.animator.SetFloat("MoveX", value);
        return;
    }

    public void Setldle(bool isIdle)
    {
        this.animator.SetBool("Idle", isIdle);
        return;
    }
}