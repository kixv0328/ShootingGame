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
    public int shootLv;                         // -> ���� ���� ��
    public SettingShoot[] settingShoots;        // -> �̸� ���õ� �߻� ���

    public GameObject bullet;                   // -> �߻� ������ ������Ʈ

    public bool isAuto;                         // -> �ڵ� �߻� ����(Enemy)

    public float maxShootDelay;                 // -> �߻� �� ������
    private float curShootDelay;                // -> �߻� �� �����̸� ����ִ� �Ǽ� ��

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

        // -> ����ó��
        if (this.shootLv >= this.settingShoots.Length)
        {
            this.shootLv = this.shootLv - 1;
        }

        return;
    }

}
