using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CHARACTER_TYPE {
    KNIGHT, SWORD_MASTER
}

public class CharacterChoice : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] GameObject[] m_characterList;

    private int m_player1Index = 0;
    private int m_player2Index = 0;
    private int m_characterMaxIndex = 1;

    private GameObject m_obj1;
    private GameObject m_obj2;
    #endregion

    #region PublicMethod
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_player1Index = IndexDown(m_player1Index);
            player1ChoicePanel();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_player1Index = IndexUp(m_player1Index);
            player1ChoicePanel();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_player2Index = IndexDown(m_player2Index);
            player2ChoicePanel();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_player2Index = IndexUp(m_player2Index);
            player2ChoicePanel();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

        }
    }

    void OnEnable()
    {
        player1ChoicePanel();
        player2ChoicePanel();
    }

    private void OnDisable()
    {
        m_player1Index = 0;
        m_player2Index = 0;
    }
    public void player1ChoicePanel()
    {
        if(m_obj1 != null)
            Destroy(m_obj1);

        Vector2 pos = new Vector2(-5, -3);
        m_obj1 = Instantiate(m_characterList[m_player1Index], pos, Quaternion.identity);

        m_obj1.transform.localScale = new Vector2(m_obj1.transform.localScale.x * 2, m_obj1.transform.localScale.y * 2);
        m_obj1.transform.localScale = new Vector2(m_obj1.transform.localScale.x, m_obj1.transform.localScale.y);

        m_obj1.transform.GetComponent<Collider2D>().enabled = false;
        m_obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public void player2ChoicePanel()
    {
        if(m_obj2 != null)
            Destroy(m_obj2);

        Vector2 pos = new Vector2(5, -3);
        m_obj2 = Instantiate(m_characterList[m_player2Index], pos, Quaternion.identity);

        m_obj2.transform.localScale = new Vector2(m_obj2.transform.localScale.x * 2, m_obj2.transform.localScale.y * 2);
        m_obj2.transform.localScale = new Vector2(m_obj2.transform.localScale.x * -1, m_obj2.transform.localScale.y);

        m_obj2.transform.GetComponent<Collider2D>().enabled = false;
        m_obj2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        m_obj2.GetComponent<Character>().SetColor();
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
    #endregion
}
