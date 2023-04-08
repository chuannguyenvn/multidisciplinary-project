using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIViewManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _viewListPlant = null;
    [SerializeField]
    private GameObject _viewARMode = null;
    [SerializeField]
    private GameObject _viewMyAccount = null;
    private void Start()
    {
        OnClickShowViewListPlant();
    }
    public void OnClickShowViewListPlant()
    {
        _viewListPlant.SetActive(true);
        _viewARMode.SetActive(false);
        _viewMyAccount.SetActive(false);
    }
    public void OnClickShowViewARMode()
    {
        _viewListPlant.SetActive(false);
        _viewARMode.SetActive(true);
        _viewMyAccount.SetActive(false);
    }
    public void OnClickShowViewAccount()
    {
        _viewListPlant.SetActive(false);
        _viewARMode.SetActive(false);
        _viewMyAccount.SetActive(true);
    }
}
