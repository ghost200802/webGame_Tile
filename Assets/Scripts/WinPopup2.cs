/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinPopup2 : MonoBehaviour
{
    public static WinPopup2 instance;
    
    public List<GameObject> listStars;
    public GameObject bgStars;
    
    [Header("Popup Reward")]
    public BBUIView popupReward;

    // public Slider sliderReward;
    private int xReward = 2;
    
    
    // public BBUIButton btnClaim;
    // public Text txtClaimCoin;
    
    // public BBUIButton btnClaimxReward;
    // public Text txtClaimxRewardCoin;
    
    [Header("Popup Action")]
    public BBUIView popupAction;

    public BBUIButton btnNextLevel;
    public BBUIButton btnHome;

    public GameObject lockGroup;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        popupReward.ShowBehavior.onCallback_Completed.AddListener(PopupReward_ShowView_Finished);
       // popupReward.HideBehavior.onCallback_Completed.AddListener(PopupReward_HideView_Finished);
        
        //popupAction.ShowBehavior.onCallback_Completed.AddListener(PopupAction_ShowView_Finished);
        //popupAction.HideBehavior.onCallback_Completed.AddListener(PopupAction_HideView_Finished);
        
        //btnClaim.OnPointerClickCallBack_Completed.AddListener(TouchClaim);
        // btnClaimxReward.OnPointerClickCallBack_Completed.AddListener(TouchClaimxReward);
        // btnClaimxReward.OnPointerClickCallBack_Start.AddListener(TouchClaimxReward_Start);
        
        btnNextLevel.OnPointerClickCallBack_Completed.AddListener(TouchNextLevel);
        btnHome.OnPointerClickCallBack_Completed.AddListener(TouchHome);
        
    }


    private void OnDestroy()
    {
        popupReward.ShowBehavior.onCallback_Completed.RemoveAllListeners();
        popupReward.HideBehavior.onCallback_Completed.RemoveAllListeners();
        
        popupAction.ShowBehavior.onCallback_Completed.RemoveAllListeners();
        popupAction.HideBehavior.onCallback_Completed.RemoveAllListeners();
        
        // btnClaim.OnPointerClickCallBack_Completed.RemoveAllListeners();
        // btnClaimxReward.OnPointerClickCallBack_Completed.RemoveAllListeners();
        // btnClaimxReward.OnPointerClickCallBack_Start.RemoveAllListeners();
        
        btnNextLevel.OnPointerClickCallBack_Completed.RemoveAllListeners();
        btnHome.OnPointerClickCallBack_Completed.RemoveAllListeners();
        
       // AdmobManager.instance.HideBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int countStar, coinValue;
    int addStar, level;
    
    public void ShowWinPopup(int _level, int _countStar, int _coinValue)
    {

        level = _level;
        countStar = _countStar;
        if(countStar == 3)
        {
            coinValue = 5;
        }
        if (countStar == 2)
        {
            coinValue = 3;
        }
        if (countStar == 1)
        {
            coinValue = 2;
        }
//        Debug.Log("coinValue " + coinValue);
        xReward = 2;
        
        if (_level < 2)
        {
            //AdmobManager.instance.HideBannerAd();
        }
        else
        {
           // AdmobManager.instance.Request_Banner();
        }
        
        addStar = countStar - Config.LevelStar(Config.currSelectLevel);
        Config.SetLevelStar(_level, _countStar);
        Config.SetChestCountStar(Config.GetChestCountStar() + addStar);
        
        // txtClaimCoin.text = $"+{coinValue}";
        // txtClaimxRewardCoin.text = $"+{coinValue * xReward}";
        
        ShowViews();
    }

    private void ShowViews()
    {
        gameObject.SetActive(true);
        lockGroup.SetActive(true);
        popupReward.gameObject.SetActive(false);
        // btnClaim.gameObject.SetActive(false);
        // btnClaimxReward.gameObject.SetActive(false);
        popupAction.gameObject.SetActive(false);
        btnNextLevel.gameObject.SetActive(false);
        btnHome.gameObject.SetActive(false);
        // bgStars.SetActive(false);
        for (int i = 0; i < listStars.Count; i++)
        {
            listStars[i].gameObject.SetActive(false);
        }

        // sliderReward.value = 0f;
        StartCoroutine(ShowViews_IEnumerator());
    }

    private IEnumerator ShowViews_IEnumerator()
    {
        yield return new WaitForSeconds(0.1f);
        popupReward.gameObject.SetActive(true);
        popupReward.GetComponent<BBUIView>().ShowView();
        
        
        yield return new WaitForSeconds(0.4f);
        if (countStar >= 1)
        {
            SoundManager.instance.PlaySound_Win();
            listStars[0].gameObject.SetActive(true);
            listStars[0].GetComponent<BBUIView>().ShowView();
        }
         
        if (countStar >= 2)
        {
            yield return new WaitForSeconds(0.1f);
            SoundManager.instance.PlaySound_Win();
            listStars[1].gameObject.SetActive(true);
            listStars[1].GetComponent<BBUIView>().ShowView();
        }
        
        if (countStar >= 3)
        {
            yield return new WaitForSeconds(0.1f);
            SoundManager.instance.PlaySound_Win();
            listStars[2].gameObject.SetActive(true);
            listStars[2].GetComponent<BBUIView>().ShowView();
        }
        
        yield return new WaitForSeconds(0.1f);
        // btnClaimxReward.gameObject.SetActive(true);
        // btnClaimxReward.GetComponent<BBUIView>().ShowView();

        // InitSlider_Reward();
        lockGroup.SetActive(false);
        
        //yield return new WaitForSeconds(0.3f);
        //btnClaim.gameObject.SetActive(true);
        //btnClaim.GetComponent<BBUIView>().ShowView();


        yield return new WaitForSeconds(0.1f);
        btnNextLevel.gameObject.SetActive(true);
        btnNextLevel.GetComponent<BBUIView>().ShowView();
        lockGroup.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        btnHome.gameObject.SetActive(true);
        btnHome.GetComponent<BBUIView>().ShowView();
    }


    private void PopupReward_ShowView_Finished()
    {
        
    }
    private void PopupReward_HideView_Finished()
    {
        StartCoroutine(OpenPopup_Action());
    }
    
    private void PopupAction_ShowView_Finished()
    {
        
    }
    private void PopupAction_HideView_Finished()
    {
        
    }

    private void TouchClaim()
    {
        lockGroup.SetActive(true);
        Config.SetCoin(Config.currCoin + coinValue);
        StartCoroutine(Claim_Finished());
    }

    private void TouchClaimxReward_Start()
    {
        lockGroup.SetActive(true);
    }
    private void TouchClaimxReward()
    {
        lockGroup.SetActive(true);
        if (Advertisements.Instance.IsRewardVideoAvailable())
        {

            Advertisements.Instance.ShowRewardedVideo(CompleteMethod);

            
        }
        else
        {
            lockGroup.gameObject.SetActive(false);
            NotificationPopup.instance.AddNotification("No Video Available!");
        }
    }

    private void CompleteMethod(bool completed, string advertiser)
    {
        Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        if (completed == true)
        {
            Config.SetCoin(Config.currCoin + coinValue * xReward);
            StartCoroutine(Claim_Finished());
        }
        else
        {
            Config.SetCoin(Config.currCoin + coinValue * xReward);
            
            StartCoroutine(Claim_Finished());

            //lockGroup.gameObject.SetActive(false);
            //NotificationPopup.instance.AddNotification("Claim Reward Fail!");
        }
    }

            private IEnumerator Claim_Finished()
    {
        yield return new WaitForSeconds(0.2f);
        //popupReward.HideView();
        lockGroup.SetActive(false);
        // btnClaimxReward.gameObject.SetActive(false);
    }

    private IEnumerator OpenPopup_Action()
    {
        lockGroup.SetActive(true);
        
        popupAction.gameObject.SetActive(true);
        popupAction.ShowView();
        
        yield return new WaitForSeconds(0.1f);
        btnNextLevel.gameObject.SetActive(true);
        btnNextLevel.GetComponent<BBUIView>().ShowView();
        lockGroup.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        btnHome.gameObject.SetActive(true);
        btnHome.GetComponent<BBUIView>().ShowView();
        
        
    }


    private void TouchNextLevel()
    {
        lockGroup.gameObject.SetActive(true);
       
        {
            GamePlayManager.instance.SetNextGame();
        }
    }

    private void TouchHome()
    {
        lockGroup.gameObject.SetActive(true);
       
        {
            SceneManager.LoadScene("Menu");
        }
    }
    
}
