using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    public static double FirstTimestamp;
    public static double m_timestamp;

    [SerializeField] Button m_daiyRewardButton;

    [SerializeField] AudioManager m_audioManager;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        m_timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        var timeElasped = m_timestamp - FirstTimestamp;
        if(timeElasped > 86400) 
        {
            m_daiyRewardButton.interactable = true;
        }
        else 
        {
            m_daiyRewardButton.interactable = false;
        }
    }

    public void GetDailyReward()
    {
        ShopSystem.Coin += 10;
        m_audioManager.playAudio("Earn Coins");
        FirstTimestamp = m_timestamp;
    }
}
