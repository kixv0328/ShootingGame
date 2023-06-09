using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SettingShoot
{
    public Transform[] position;
}

public class WaeponSystem : MonoBehaviour
{
    public SettingShoot[] SettingShoot;

    public GameObject bullet;
    public float maxShootDelay;
    private float curShootDelay;

    private void Update()
    {
        FireShoot();
        return;
    }
    
    private void FireShoot()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (this.curShootDelay < 0f)
            {
                this.curShootDelay = this.maxShootDelay;
                Instantiate(this.bullet, this.transform.position, this.transform.rotation);
            }
        }

        this.curShootDelay = this.curShootDelay - Time.deltaTime * 1f;

        return;
    }
}
