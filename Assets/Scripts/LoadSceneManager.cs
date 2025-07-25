﻿/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UomaWeb;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Config.GetSound();
        Config.GetMusic();
        Config.currCoin = Config.GetCoin();
        Config.currPiggyBankCoin = Config.GetPiggyBank();
        Config.GetLevelStar();
        if (Config.isMusic)
        {
            MusicManager.instance.PlayMusicBG();
        }

        StartCoroutine(UomaController.Instance.GetVirtualCurrency((int currency) =>
        {
            StartCoroutine(UomaController.Instance.GetCompleteLevel((int result) =>
            {
                StartCoroutine(LoadMenuScene_IEnumerator());
            }));
        }));
        
        
        //TODO: Check Chest Star
         //Config.SetChestCountStar(15);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LoadMenuScene_IEnumerator() {
        yield return new WaitForSeconds(2f);
        LoadMenuScene();
    }
    bool isLoadMenu = false;
    public void LoadMenuScene() {
        if (!isLoadMenu)
        {
            //isLoadMenu = true;
            if (UomaDataManager.CurrLevel == 1)
            {
                SceneManager.LoadSceneAsync("Play");

            }
            else
            {
                SceneManager.LoadSceneAsync("Menu");
            }

            //SceneManager.LoadSceneAsync("Menu");
        }
    }
}
