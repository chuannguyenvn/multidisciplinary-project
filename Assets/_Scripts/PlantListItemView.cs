using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantListItemView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name = null;
    [SerializeField]
    private Image _img = null;
    [Space]
    [SerializeField]
    private GameObject _prefafStamp = null;
    [SerializeField]
    private GameObject _content = null;

    private List<GameObject> _lstStampInfo = new List<GameObject>();
    public void SpawnStampInfo()
    {
        if (_lstStampInfo.Count <= 1)
        {
            //Utility.InstantiateObject<>
        }
    }
    public void OnClickSpawnInfoPanel()
    {

    }
}