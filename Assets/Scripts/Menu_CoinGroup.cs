﻿/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UomaWeb;

public class Menu_CoinGroup : MonoBehaviour
{
    public BBUIButton btnAddCoin;
    public Text txtCoin;
    // Start is called before the first frame update
    void Start()
    {
        //btnAddCoin.OnPointerClickCallBack_Completed.AddListener(TouchAddCoin);
        // Config.OnChangeCoin += OnChangeCoin;
        ShowCoin();
    }

    private void OnDestroy()
    {
        // Config.OnChangeCoin -= OnChangeCoin;
    }

    // Update is called once per frame
    void Update()
    {
        txtCoin.text = $"{UomaDataManager.GetVirtualCurrency()}";
    }

    public void OnChangeCoin(int coinValue) {
        ShowCoin();
    }

    public void ShowCoin() {
        DOTween.Kill(txtCoin.transform);
        
        txtCoin.text = $"{UomaDataManager.GetVirtualCurrency()}";
        txtCoin.transform.localScale = Vector3.one;
        txtCoin.transform.DOPunchScale(Vector3.one * 0.3f, 0.2f, 10, 2f).SetEase(Ease.InOutBack).SetRelative(true).SetLoops(3,LoopType.Restart);
    }

    public void TouchAddCoin() {
        MenuManager.instance.OpenShopCoin();
    }
}
