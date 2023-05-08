using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using TMPro;

public class FacebookController : MonoBehaviour
{
    public GameObject m_usernameField;

    private void Awake()
    {
        FB.Init(SetInit,OnHideUnity);
    }

    void SetInit()
    {
        if(FB.IsLoggedIn)
        {
            Debug.Log("logged in sucessfully");
        }
        else
        {
            Debug.Log("Is not logged in");
        }
    } 

    void OnHideUnity(bool isGameShow)
    {
        if (isGameShow)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void FBLogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("Public_Profile");
        Debug.Log(permissions);
        FB.LogInWithReadPermissions(permissions, AuthCallResult);
    }

    void AuthCallResult(ILoginResult result)
    {
        if(result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if(FB.IsLoggedIn)
            {
                Debug.Log("Is logged in");
                FB.API("/m?fields=first_name",HttpMethod.GET,CallbackData);
            }
            else
            {
                Debug.Log("Login failed");
            }
        }
    }

    void CallbackData(IResult res)
    {
        TextMeshProUGUI username = m_usernameField.GetComponent<TextMeshProUGUI>();
        if(res.Error != null)
        {
            Debug.Log("Error geeting data");
        }
        else
        {
            username.text = "Welcome Back! " + res.ResultDictionary["first_name"];
        }
    }
}
