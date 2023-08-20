using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region PublicVariables
    public static PlayerManager instance;

    public GameObject m_player1;
    public GameObject m_player2;

    public bool isTutorialPlayed = false;
    #endregion

    #region PrivateVariables


    [SerializeField] private List<TutorialButton> m_keyName = new List<TutorialButton>();

    private Character m_player1Controller;
    private Character m_player2Controller;
    #endregion

    #region PublicMethod
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {   
        m_player1Controller = m_player1.GetComponent<Character>();
        m_player2Controller = m_player2.GetComponent<Character>();

        //AddTutorialKey(ref m_player1, 0, 7);
        //AddTutorialKey(ref m_player2, 7, 7);
    }
    private void Update()
    {
        PlayerInput();
    }
    
    public void MovePlayerPosition(Vector2 _pos1, Vector2 _pos2)
    {
        m_player1.transform.position = _pos1;
        m_player2.transform.position = _pos2;
    }

    public void InitLife()
    {
        m_player1Controller.m_life = 5;
        m_player2Controller.m_life = 5;

        m_player1Controller.m_isDead = false;
        m_player2Controller.m_isDead = false;
    }

    public void SetPlayerColor()
    {
        m_player2.GetComponent<Character>().SetColor();
    }
    #endregion

    #region PrivateMethod
    private void PlayerInput()
    {   
        if(ESCMenu.g_pause == true)
        {
            return;
        }

        //Player1 Action
        if (Input.GetKey(KeyCode.A))
        {
            m_player1Controller.Move(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_player1Controller.Move(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_player1Controller.Jump();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            m_player1Controller.Command1();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            m_player1Controller.Command2();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            m_player1Controller.Command3();
        }

        //Player2 Action
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_player2Controller.Move(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_player2Controller.Move(1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_player2Controller.Jump();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            m_player2Controller.Command1();
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            m_player2Controller.Command2();
        }
        if (Input.GetKeyDown(KeyCode.Quote))
        {
            m_player2Controller.Command3();
        }
    }

    private void AddTutorialKey(ref GameObject _player, int _index, int _range)
    {
        for(int i=_index; i<_index + _range; i++)
        {
            _player.GetComponent<Player>().m_tutorialKeyInput.Add(m_keyName[i]);
        }
    }
    #endregion
}
