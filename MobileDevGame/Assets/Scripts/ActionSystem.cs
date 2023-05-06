using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    //bool
    public bool m_HasActed;

    //Barriers
    public int m_P1BarrierCount;
    public GameObject[] m_P1Barriers;
    public int m_P2BarrierCount;
    public GameObject[] m_P2Barriers;

    //Turrets
    public int m_P1TurretCount;
    public GameObject[] m_P1Turrets;
    public int m_P2TurretCount;
    public GameObject[] m_P2Turrets;

    //Forts
    public int m_P1FortCount;
    public GameObject[] m_P1Forts;
    public int m_P2FortCount;
    public GameObject[] m_P2Forts;

    //Scripts
    public TurnSystem m_TurnSystem;
    public AudioManager m_AudioManager;
    public DiceSystem m_DiceSystem;

    //Fade in
    public float m_FadeInTime = 1f;

    [Header("Sprite")]
    [SerializeField] Sprite m_explosion;
    [SerializeField] Sprite m_redSprite;
    [SerializeField] Sprite m_blueSprite;
    [SerializeField] Sprite m_greenSprite;

    [Header("Sprite Renderer")]
    [SerializeField] SpriteRenderer[] m_p1Sprites;
    [SerializeField] SpriteRenderer[] m_p2Sprites;

    // Start is called before the first frame update
    void Start()
    {
        //set sprites


        for (int i = 0; i < m_p1Sprites.Length; i++)
        {
            if(EquipSystem.P1RedEquiped)
            {
                m_p1Sprites[i].sprite = m_redSprite;
            }
            if(EquipSystem.P1BlueEquiped)
            {
                m_p1Sprites[i].sprite = m_blueSprite;
            }
            if(EquipSystem.P1GreenEquiped)
            {
                m_p1Sprites[i].sprite = m_greenSprite;
            }
        }
        for (int i = 0; i < m_p2Sprites.Length; i++)
        {
            if (EquipSystem.P2RedEquiped)
            {
                m_p2Sprites[i].sprite = m_redSprite;
            }
            if (EquipSystem.P2BlueEquiped)
            {
                m_p2Sprites[i].sprite = m_blueSprite;
            }
            if (EquipSystem.P2GreenEquiped)
            {
                m_p2Sprites[i].sprite = m_greenSprite;
            }
        }

        //Set Barriers
        m_P1BarrierCount = 0;
        for (int i = 0; i < m_P1Barriers.Length; i++)
        {
            m_P1Barriers[i].SetActive(false);
            StartCoroutine(Invisible(m_P1Barriers[i].GetComponent<SpriteRenderer>()));
        }
        m_P2BarrierCount = 0;
        for (int i = 0; i < m_P2Barriers.Length; i++)
        {
            m_P2Barriers[i].SetActive(false);
            StartCoroutine(Invisible(m_P2Barriers[i].GetComponent<SpriteRenderer>()));
        }

        //Set Turrets
        m_P1TurretCount = 0;
        for (int i = 0; i < m_P1Turrets.Length; i++)
        {
            m_P1Turrets[i].SetActive(false);
            StartCoroutine(Invisible(m_P1Turrets[i].GetComponent<SpriteRenderer>()));
        }
        m_P2TurretCount = 0;
        for (int i = 0; i < m_P2Turrets.Length; i++)
        {
            m_P2Turrets[i].SetActive(false);
            StartCoroutine(Invisible(m_P2Turrets[i].GetComponent<SpriteRenderer>()));
        }

        //Set Forts
        m_P1FortCount = m_P1Forts.Length;
        m_P2FortCount = m_P2Forts.Length;

        //Set Bool
        m_HasActed = true;
    }

    public void P1BuildBarrier()
    {
        if(m_P1BarrierCount < 3 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P1ACTION)
        {
            m_AudioManager.playAudio("Draw");
            m_P1Barriers[m_P1BarrierCount].SetActive(true);
            StartCoroutine(DoFadeIn(m_P1Barriers[m_P1BarrierCount].GetComponent<SpriteRenderer>()));
            m_P1BarrierCount++;
            m_HasActed = true;
            m_TurnSystem.m_P1Text.text = "Barrier Built";
        }
        else if (m_P1BarrierCount >= 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Can't build more Barriers";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }

    public void P1BuildTurret()
    {
        if (m_P1TurretCount < 3 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P1ACTION)
        {
            m_AudioManager.playAudio("Draw");
            m_P1Turrets[m_P1TurretCount].SetActive(true);
            StartCoroutine(DoFadeIn(m_P1Turrets[m_P1TurretCount].GetComponent<SpriteRenderer>()));
            m_P1TurretCount++;
            m_HasActed = true;
            m_TurnSystem.m_P1Text.text = "Turret Built";
        }
        else if (m_P1TurretCount >= 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Can't build more Turrets";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2BuildBarrier()
    {
        if (m_P2BarrierCount < 3 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P2ACTION)
        {
            m_AudioManager.playAudio("Draw");
            m_P2Barriers[m_P2BarrierCount].SetActive(true);
            StartCoroutine(DoFadeIn(m_P2Barriers[m_P2BarrierCount].GetComponent<SpriteRenderer>()));
            m_P2BarrierCount++;
            m_HasActed = true;
            m_TurnSystem.m_P2Text.text = "Barrier Built";
        }
        else if (m_P2BarrierCount >= 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Can't build more Barriers";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P2BuildTurret()
    {
        if (m_P2TurretCount < 3 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P2ACTION)
        {
            m_AudioManager.playAudio("Draw");
            m_P2Turrets[m_P2TurretCount].SetActive(true);
            StartCoroutine(DoFadeIn(m_P2Turrets[m_P2TurretCount].GetComponent<SpriteRenderer>()));
            m_P2TurretCount++;
            m_HasActed = true;
            m_TurnSystem.m_P2Text.text = "Turret Built";
        }
        else if (m_P2TurretCount >= 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Can't build more Turrets";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackTurret()
    {
        if (m_P1TurretCount != 0 && m_P2TurretCount != 0 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P1ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P2Turrets[m_P2TurretCount - 1].GetComponent<SpriteRenderer>(), m_P2Turrets[m_P2TurretCount - 1]));
            m_P2TurretCount--;
            m_TurnSystem.m_P1Text.text = "P2 Turret Destroyed!";
            Handheld.Vibrate();
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Turrets on field";
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Turret to destroy";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackTurret()
    {
        if (m_P2TurretCount != 0 && m_P1TurretCount != 0 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P2ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P1Turrets[m_P1TurretCount - 1].GetComponent<SpriteRenderer>(), m_P1Turrets[m_P1TurretCount - 1]));
            m_P1TurretCount--;
            Handheld.Vibrate();
            m_TurnSystem.m_P2Text.text = "P1 Turret Destroyed!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "No Turrets on field";
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Turret to destroy";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackBarrier()
    {
        if (m_P1TurretCount != 0 && m_P2BarrierCount != 0 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P1ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P2Barriers[m_P2BarrierCount - 1].GetComponent<SpriteRenderer>(), m_P2Barriers[m_P2BarrierCount - 1]));
            m_P2BarrierCount--;
            Handheld.Vibrate();
            m_TurnSystem.m_P1Text.text = "P2 Barrier Destroyed!";
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Turrets on the field";
        }
        else if (m_P2BarrierCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Barrier to destroy";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackBarrier()
    {
        if (m_P2TurretCount != 0 && m_P1BarrierCount != 0 && m_HasActed == false && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P2ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P1Barriers[m_P1BarrierCount - 1].GetComponent<SpriteRenderer>(), m_P1Barriers[m_P1BarrierCount - 1]));
            m_P1BarrierCount--;
            Handheld.Vibrate();
            m_TurnSystem.m_P2Text.text = "P1 Barrier Destroyed!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "No Turrets on the field";
        }
        else if (m_P1BarrierCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "No Barrier to destroy";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackFort()
    {
        if (m_P1TurretCount != 0 && m_P2FortCount != 0 && m_HasActed == false && m_P2BarrierCount == 0 && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P1ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P2Forts[m_P2FortCount - 1].GetComponent<SpriteRenderer>(), m_P2Forts[m_P2FortCount - 1]));
            m_P2FortCount--;
            Handheld.Vibrate();
            m_TurnSystem.m_P1Text.text = "P2 Fort Damaged!";
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "No Turrets on the field";
        }
        else if (m_P2BarrierCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Their Fort is Protected";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackFort()
    {
        if (m_P2TurretCount != 0 && m_P1FortCount != 0 && m_HasActed == false && m_P1BarrierCount == 0 && m_TurnSystem.m_CurrentState == TurnSystem.TurnState.P2ACTION)
        {
            m_AudioManager.playAudio("Boom");
            StartCoroutine(Explosion(m_P1Forts[m_P1FortCount - 1].GetComponent<SpriteRenderer>(), m_P1Forts[m_P1FortCount - 1]));
            m_P1FortCount--;
            Handheld.Vibrate();
            m_TurnSystem.m_P2Text.text = "P1 Fort Damaged!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "No Turrets on the field";
        }
        else if (m_P1BarrierCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Their Fort is Protected";
        }
        else
        {
            m_AudioManager.playAudio("Error");
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    IEnumerator Invisible(SpriteRenderer Sprite)
    {
        Color tempColor = Sprite.color;

        while (tempColor.a >= 1f)
        {
            Debug.Log("Invisible");
            tempColor.a = 0f;
            Sprite.color = tempColor;

            yield return null;
        }

        Sprite.color = tempColor;
    }

    IEnumerator DoFadeIn(SpriteRenderer Sprite)
    {
        Color tempColor = Sprite.color;

        while (tempColor.a < 1f)
        {
            Debug.Log("Fading In");
            tempColor.a += Time.deltaTime / m_FadeInTime;
            Sprite.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1.0f;
            }

            yield return null; 
        }

        Sprite.color = tempColor;
    }

    IEnumerator Explosion(SpriteRenderer Sprite, GameObject DestroyedObject)
    {
        Color tempColor = Sprite.color;

        Sprite tempSprite = Sprite.sprite;

        Sprite.sprite = m_explosion; 

        while (tempColor.a > 0f)
        {
            Debug.Log("Boom");
            tempColor.a -= Time.deltaTime / m_FadeInTime;
            Sprite.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
            }

            yield return null;
        }

        DestroyedObject.SetActive(false);

        Sprite.color = tempColor;

        Sprite.sprite = tempSprite;
    }

    void ChangeSprite()
    {
        
    }
}
