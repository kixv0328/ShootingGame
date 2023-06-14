using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public float delay;

    private void Start()
    {
        Invoke("DelayDie", this.delay);
        return;
    }

    public void DelayDie()
    {
        Destroy(this.gameObject);
        return;
    }
}
