using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour
{
    public EffectSystem effectSystem;

    public void DropEffect()
    {
        Vector2 t_Pos = this.transform.position;
        Quaternion t_Qua = Quaternion.identity;
        Instantiate(this.effectSystem, t_Pos, t_Qua);
        return;
    }
}
