using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARController : MonoBehaviour
{
    public void OnClickShowPanelInfo()
    {
        SceneManager.Instance.ChangeScene(Define.SceneName.Main.ToString(), new SceneManager.Param { viewName = Define.ViewName.PlantInfor });
    }
    public void OnWaterNow()
    {
        Debug.LogError("water");
    }
}
