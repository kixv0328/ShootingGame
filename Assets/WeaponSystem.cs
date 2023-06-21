using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingShoot
{
    public Transform[] positions;
}

public class WeaponSystem : MonoBehaviour
{
    public int shootLv;                         // -> 레벨 정수 값
    public SettingShoot[] settingShoots;        // -> 미리 세팅된 발사 방식

    public GameObject bullet;                   // -> 발사 생성될 오브젝트

    public bool isAuto;                         // -> 자동 발사 유무(Enemy)

    public float maxShootDelay;                 // -> 발사 당 딜레이
    private float curShootDelay;                // -> 발사 당 딜레이를 담아주는 실수 값

    private void Update()
    {
        FireShoot();
        return;
    }

    private void FireShoot()
    {
        if ((Input.GetKey(KeyCode.Space) && !this.isAuto) || this.isAuto)
        {
            if (this.curShootDelay < 0f)
            {
                this.curShootDelay = this.maxShootDelay;

                int tempShootCount = this.settingShoots[this.shootLv].positions.Length;
                for (int i = 0; i < tempShootCount; i++)
                {
                    Vector2 tempShootPostion = this.settingShoots[this.shootLv].positions[i].position;
                    Quaternion tempShootQuaternion = this.settingShoots[this.shootLv].positions[i].rotation;
                    Instantiate(this.bullet, tempShootPostion, tempShootQuaternion);
                }
            }
        }

        this.curShootDelay = this.curShootDelay - Time.deltaTime * 1f;
        return;
    }

    public void GradeUp()
    {
        this.shootLv = this.shootLv + 1;

        // -> 예외처리
        if (this.shootLv >= this.settingShoots.Length)
        {
            this.shootLv = this.shootLv - 1;
        }

        return;
    }

}
