using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using PlayFab;
using TMPro;
using System;

public class PlayfabAuth : MonoBehaviour
{
    string TitleId = "A0000";
    [SerializeField]TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        if (FB.IsInitialized)
            return;
        FB.Init(()=>FB.ActivateApp());
    }
    public void LoginWithFacebook()
    {
        FB.LogInWithReadPermissions(new List<string> { "public_profile", "email" }, Res =>
        {
            LoginWithPlayfab();
        });
    }
    public void LoginWithPlayfab()
    {
        PlayFabClientAPI.LoginWithFacebook(new PlayFab.ClientModels.LoginWithFacebookRequest
        {
            TitleId = TitleId,
            AccessToken = AccessToken.CurrentAccessToken.TokenString,
            CreateAccount = true
        }, PlayfabLoginSuccess, playfabLoginFailed);
    }
    public void PlayfabLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        textMeshProUGUI.text = "LoginSucessfull"; 
    }
    public void playfabLoginFailed(PlayFabError error)
    {
        textMeshProUGUI.text = "LoginFailed";
    }
}
