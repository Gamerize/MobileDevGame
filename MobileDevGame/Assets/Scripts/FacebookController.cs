using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebookController : MonoBehaviour
{
    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0f;
                else
                    Time.timeScale = 1f;
            });
        }
        else
            FB.ActivateApp();
    }

    #region Login / Logout
    public void FBLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
    }

    public void FBLogout()
    {
        FB.LogOut();
    }
    #endregion

    public void FBShare()
    {
        FB.ShareLink(new System.Uri("https://github.com/Gamerize/MobileDevGame"),"Check it out", "Casual Multiplayer Game", new System.Uri("https://gamerize.github.io/issacwai.github.io/images/pic11.png"));
    }
}
