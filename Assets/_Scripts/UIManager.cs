using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image _img = null;
    public void OnClickBtnRed()
    {
        _img.color = Color.red;
    }
    public void OnClickBtnBlue()
    {
        _img.color = Color.blue;
    }
}
