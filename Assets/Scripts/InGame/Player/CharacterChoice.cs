using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum CHARACTER_TYPE {
    KNIGHT, SWORD_MASTER
}

public class CharacterChoice : MonoBehaviour
{
    #region PublicVariables
    public static CharacterChoice instance;
    #endregion

    #region PrivateVariables
    [SerializeField] GameObject[] m_characterList;

    [SerializeField] GameObject m_player1SelectText;
    [SerializeField] GameObject m_player2SelectText;
    [SerializeField] GameObject m_pressEnter;

    private bool m_isscreenOn = false;

    private int m_player1Index = 0;
    private int m_player2Index = 0;
    private int m_characterMaxIndex = 1;
    private bool m_isPlayer1Selected = false;
    private bool m_isPlayer2Selected = false;
    private Vector2 m_spawnPos = new Vector2(100, 100);

    private GameObject m_obj1;
    private GameObject m_obj2;
    #endregion

    #region PublicMethod
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (m_isscreenOn == false)
            return;
        
        if(m_isPlayer1Selected == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_player1Index = IndexDown(m_player1Index);
                Player1ChoicePanel();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_player1Index = IndexUp(m_player1Index);
                Player1ChoicePanel();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                Player1Choice();
                m_player1SelectText.SetActive(true);
            }
        }
            
        if(m_isPlayer2Selected == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_player2Index = IndexDown(m_player2Index);
                Player2ChoicePanel();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_player2Index = IndexUp(m_player2Index);
                Player2ChoicePanel();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Player2Choice();
                m_player2SelectText.SetActive(true);
            }
        }


        if (m_isPlayer1Selected == true && m_isPlayer2Selected == true)
        {
            m_pressEnter.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("¿Ï·á");
                CompleteChoicePlayer();
                
            }
        }
        
    }


    public void ShowCharactercreen()
    {
        ShowCharacters();
        m_isscreenOn = true;
        gameObject.SetActive(true);
    }

    public void HideCharacterScreen()
    {
        HideCharacters();
        m_isscreenOn = false;
        gameObject.SetActive(false);
    }

    public void Player1ChoicePanel()
    {
        DestroyPlayer(ref m_obj1);

        Vector2 pos = new Vector2(-5, -3);
        m_obj1 = Instantiate(m_characterList[m_player1Index], pos, Quaternion.identity);

        m_obj1.transform.localScale = new Vector2(m_obj1.transform.localScale.x * 3, m_obj1.transform.localScale.y * 3);
        m_obj1.transform.localScale = new Vector2(m_obj1.transform.localScale.x, m_obj1.transform.localScale.y);

        m_obj1.transform.GetComponent<Collider2D>().enabled = false;
        m_obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public void Player2ChoicePanel()
    {
        DestroyPlayer(ref m_obj2);

        Vector2 pos = new Vector2(5, -3);
        m_obj2 = Instantiate(m_characterList[m_player2Index], pos, Quaternion.identity);

        m_obj2.transform.localScale = new Vector2(m_obj2.transform.localScale.x * 3, m_obj2.transform.localScale.y * 3);
        m_obj2.transform.localScale = new Vector2(m_obj2.transform.localScale.x * -1, m_obj2.transform.localScale.y);

        m_obj2.transform.GetComponent<Collider2D>().enabled = false;
        m_obj2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        m_obj2.GetComponent<Character>().SetColor();
    }

    private void OnEnable()
    {
        m_isPlayer1Selected = false;
        m_isPlayer2Selected = false;
    }

    private void OnDisable()
    {
        HideCharacters();
        m_isscreenOn = false;
        m_isPlayer1Selected = false;
        m_isPlayer2Selected = false;

        m_player1SelectText.SetActive(false);
        m_player2SelectText.SetActive(false);
        m_pressEnter.SetActive(false);
    }
    #endregion

    #region PrivateMethod
    private int IndexDown(int _index)
    {
        if (_index == 0)
            return m_characterMaxIndex;

        return --_index;
    }

    private int IndexUp(int _index)
    {
        if (_index == m_characterMaxIndex)
            return 0;

        return ++_index;
    }

    private void ChoiceCharacter(){

    }

    private void ShowCharacters()
    {
        Player1ChoicePanel();
        Player2ChoicePanel();
    }

    private void HideCharacters()
    {
        m_player1Index = 0;
        m_player2Index = 0;
    }

    private void DestroyPlayer(ref GameObject _obj)
    {
        if (_obj != null)
            Destroy(_obj);
    }

    private void Player1Choice()
    {   
        m_isPlayer1Selected = true;
        GameObject obj = Instantiate(m_characterList[m_player1Index], m_spawnPos, Quaternion.identity);

        PlayerManager.instance.m_player1 = obj;
    }

    private void Player2Choice()
    {
        m_isPlayer2Selected = true;
        GameObject obj = Instantiate(m_characterList[m_player2Index], m_spawnPos, Quaternion.identity);

        PlayerManager.instance.m_player2 = obj;
        PlayerManager.instance.SetPlayerColor();
    }

    private void CompleteChoicePlayer()
    {
        PlayerManager.instance.GetPlayerInfo();
       
        gameObject.SetActive(false);

        DestroyPlayer(ref m_obj1);
        DestroyPlayer(ref m_obj2);

        GameManager.instance.OnStageScreen();
    }
    #endregion
}
