using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIHeartContainer : MonoBehaviour
{
	#region PublicVariables
	public int m_index = 0;
	#endregion

	#region PrivateVariables
	[SerializeField] private List<UIHeart> m_hearts = new List<UIHeart>();
	[SerializeField] private GameObject[] m_characterSpriteList;
	[SerializeField] private GameObject m_characterUIParent;
	[SerializeField] private GameObject m_obj;


	private static WaitForSeconds m_heartsGenerateDelay = new WaitForSeconds(0.15f);
	[SerializeField] private Vector3 m_pos = Vector3.zero;
	[SerializeField] private int m_dir;
	private int index;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		index = 0;
		foreach (UIHeart heart in m_hearts)
		{
			heart.Initialize();
		}
		MakeCharacterUI();
    }

	public bool PopAndReturnRevivalPossibility()
	{
		m_hearts[index].Pop();
		++index;
		if(index >= m_hearts.Count)
		{
			HeartCountOut();
			return false;
		}
		return true;
	}

	public void DeleteCharacterUI()
	{
		Destroy(m_obj);
	}
	#endregion

	#region PrivateMethod
	private void HeartCountOut()
	{
		GameManager.instance.GameEnd();
		MSStageManager.instance.StageEnd();
    }

	private void MakeCharacterUI()
	{
		m_characterUIParent.transform.position = Vector3.zero;
		m_characterUIParent.transform.localScale = new Vector3(1, 1, 1);

		m_obj = Instantiate(m_characterSpriteList[m_index], Vector3.zero, Quaternion.identity);
        m_obj.transform.SetParent(m_characterUIParent.transform);

        m_obj.transform.localScale = new Vector3(m_obj.transform.localScale.x * m_dir, m_obj.transform.localScale.y, m_obj.transform.localScale.z);
		m_obj.transform.position = m_pos + m_characterUIParent.transform.position;
 

        if (m_dir == -1)
		{
			m_obj.GetComponent<HeartUI>().SetColor();
		}
	}
	#endregion
}
