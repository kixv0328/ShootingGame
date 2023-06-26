using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SettingEnemyDrop
{
    public float readyDelay;
    public EnemySystem dropEnemy;
    public float dropDelay;
}

public class EnemySpawer : MonoBehaviour
{
    [Header("영역")]
    public BoxCollider2D boxCollider2D;

    [Header("스폰 딜레이")]
    public float curDropDelay;
    public float maxDropDelay;

    [Header("세팅 값")]
    public SettingEnemyDrop[] settingEnemyDrops;

    private void Start()
    {
        foreach (var item in this.settingEnemyDrops)
        {
            StartCoroutine(AutoDropSystem(item.readyDelay, item.dropDelay));
        }
        return;
    }

    IEnumerator AutoDropSystem(float sTime, float mD, EnemySystem eSye)
    {
        yield return new WaitForSeconds(sTime);

        float t_CurDropDelay = 0f;
        float t_MaxDropDelay = mD;
        EnemySystem t_DropEnemy = eSye;

        while (true)
        {
            if (t_CurDropDelay < 0f)
            {
                t_CurDropDelay = t_MaxDropDelay;
                float t_DropX = Random.Range(this.boxCollider2D.bounds.min.x, this.boxCollider2D.bounds.max.x);
                float t_DropY = Random.Range(this.boxCollider2D.bounds.min.y, this.boxCollider2D.bounds.max.y);
            }
        }


        yield break;
    }

}
