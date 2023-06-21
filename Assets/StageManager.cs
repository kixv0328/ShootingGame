using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingStage
{
    public float delay;
    public GameObject stage;
}

public class StageManager : MonoBehaviour
{
    // -> ���������� �ϳ��� ��������ִ� ��ũ��Ʈ

    public SettingStage[] settingStages;

    private void Start()
    {
        for (int i = 0; i < this.settingStages.Length; i++)
        {
            StartCoroutine(AutoPlayStage(this.settingStages[i]));
        }

        return;
    }

    IEnumerator AutoPlayStage(SettingStage s)
    {
        yield return new WaitForSeconds(s.delay);
        s.stage.SetActive(true);

        yield break;
    }
}
