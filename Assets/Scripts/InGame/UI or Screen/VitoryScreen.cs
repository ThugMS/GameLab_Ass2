using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class VitoryScreen : MonoBehaviour
{
    #region PublicVariables
    public static VitoryScreen instance;
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject[] m_characterList;
    [SerializeField] private TextMeshPro m_textMeshPro;

    private GameObject m_victoryObj;

    private bool m_player1IsDead = false;
    private bool m_player2IsDead = false;

    private CHARACTER_TYPE m_characterType;
    private Vector2 m_spawnPos = new Vector2 (0, -3);
    private Vector2 m_scale = new Vector2(3, 3);

    #endregion

    #region PublicMethod

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.instance.OffVictoryScreen();
        }
    }
    public void ShowVictoryPlayer()
    {
        InitPlayerDead();
        GetVictoryPlayer();

        if (m_player1IsDead)
        {
            m_characterType = PlayerManager.instance.m_player2.GetComponent<Character>().m_type;
            m_victoryObj = Instantiate(m_characterList[(int)m_characterType], m_spawnPos, Quaternion.identity);
            m_victoryObj.transform.localScale = m_scale;
            m_victoryObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            m_victoryObj.GetComponent<Character>().SetColor();
        }
        else if (m_player2IsDead)
        {
            m_characterType = PlayerManager.instance.m_player1.GetComponent<Character>().m_type;
            m_victoryObj = Instantiate(m_characterList[(int)m_characterType], m_spawnPos, Quaternion.identity);
            m_victoryObj.transform.localScale = m_scale;
            m_victoryObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        FillVictoryName();
    }

    public void HideVictoryPlayer()
    {
        Destroy(m_victoryObj);
    }

    public void OnVictoryScreen()
    {   
        ShowVictoryPlayer();
        gameObject.SetActive(true);
    }

    public void OffVictoryScreen()
    {
        HideVictoryPlayer();
        gameObject.SetActive(false);
    }
    #endregion

    #region PrivateMethod
    private void GetVictoryPlayer()
    {
        m_player1IsDead = PlayerManager.instance.m_player1.GetComponent<Character>().m_isDead;
        m_player2IsDead = PlayerManager.instance.m_player2.GetComponent<Character>().m_isDead;
    }

    private void FillVictoryName()
    {
        string s = "";

        if (m_player1IsDead == true)
        {
            s = "Player 2 WIN!!";
        }
        else
        {
            s = "Player 1 WIN!!";
        }

        m_textMeshPro.text = s;
    }

    private void InitPlayerDead()
    {
        m_player1IsDead = false;
        m_player2IsDead = false;
    }
    #endregion
}
