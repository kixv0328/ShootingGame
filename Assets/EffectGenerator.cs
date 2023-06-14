using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour
{
    public EffectGenerator EffectSystem;

    public void DropEffect()
    {
        Vector2 t_Pos = this.transform.position;
        Quaternion t_Qut = Quaternion.identity;
        Instantiate(this.EffectSystem, t_Pos, t_Qut);
        return;
    }
}
