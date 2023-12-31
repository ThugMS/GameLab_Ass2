using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	public UnityEvent onGameTutorial;
	public UnityEvent onGameStart;
	public UnityEvent onGameEnd;

	public UnityEvent onMainScreen;
    public UnityEvent offMainScreen;

	public UnityEvent chagneCharacter;

	public UnityEvent onCharacterScreen;
	public UnityEvent offCharacterScreen;

	public UnityEvent onStageScreen;
    public UnityEvent offStageScreen;

    public UnityEvent onVictoryScreen;
    public UnityEvent offVictoryScreen;
    #endregion

    #region PrivateVariables
    #endregion

    #region PublicMethod
    public void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public void TutorialStart()
	{
		onGameTutorial.Invoke();
	}
	public void GameStart()
	{
		onGameStart.Invoke();
	}
	public void GameEnd()
	{
		onGameEnd.Invoke();
        onVictoryScreen.Invoke();
    }

	public void OnMainScreen()
	{
		onMainScreen.Invoke();
	}

    public void OffMainScreen()
    {
        offMainScreen.Invoke();
    }

	public void OnCharacterChoiceScreen()
	{
		onCharacterScreen.Invoke();
	}

	public void OffCharacterChoiceScreen()
	{
        offCharacterScreen.Invoke();
    }

	public void ChangeCharacter()
	{
		chagneCharacter.Invoke();
	}

	public void OnStageScreen()
	{
		onStageScreen.Invoke();
	}

	public void OffStageScreen()
	{
		offStageScreen.Invoke();
	}

	public void OnVictoryScreen()
	{
		onVictoryScreen.Invoke();
    }

	public void OffVictoryScreen()
	{
		offVictoryScreen.Invoke();
		onMainScreen.Invoke();
	}
    #endregion

    #region PrivateMethod
    #endregion
}
