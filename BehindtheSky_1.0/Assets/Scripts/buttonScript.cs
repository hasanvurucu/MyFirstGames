using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {

	public static int metalResource;
	public static int titaniumResource;

	public float protectionTimer;

	public GameObject playAgainButton;
	public GameObject pauseButton;
	public GameObject unpauseButton;
	public GameObject startGameButton;
	public GameObject buyShieldButton;
	public GameObject buyBoostButton;
	public GameObject resumeButton;
	public GameObject exitButton;

	public GameObject boosterObj;
	public GameObject shieldObj;

	public playerScript pScr;
	public cameraMovement camMov;
	public playerMovement pMovSc;
	public resourceManageScript resManageSc;

	private int i;

	public int rewardOrResume = 0; //1 is reward, 2 is resume

	public bool videoWatch = false;

	public bool gamePause;

	public void OnMouseDownPlay()
	{
		SceneManager.LoadScene ("main");
	}
	public void quitButton()
	{
		Application.Quit ();
	}
	public void storeButton()
	{
		SceneManager.LoadScene ("store");
	}
	public void optionsButton()
	{
		SceneManager.LoadScene ("options");
	}
	public void howToPlayButton()
	{
		SceneManager.LoadScene ("howToPlay");
	}
	public void backButtonToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("menu");
	}
	public void playAgain()
	{
		Time.timeScale = 1;
		playAgainButton.SetActive(false);
		SceneManager.LoadScene ("main");
	}
	public void pauseButtonMethod()
	{
		gamePause = true;
		Time.timeScale = 0f;
		pauseButton.SetActive (false);
		unpauseButton.SetActive (true);
		resumeButton.SetActive (true);
		exitButton.SetActive (true);
	}
	public void unpauseButtonMethod()
	{
		gamePause = false;
		Time.timeScale = 1f;
		unpauseButton.SetActive (false);
		resumeButton.SetActive (false);
		exitButton.SetActive (false);
		pauseButton.SetActive (true);
	}
	public void rewardedVideoWatchButton()
	{
		rewardOrResume = 1;
		videoWatch = true;
	}
	public void videoToResumeButton()
	{
		rewardOrResume = 2;
		videoWatch = true;
	}
	public void skipRequestButton()
	{
		Time.timeScale = 1;
		pScr.waitForInput = true;
	}
	public void startGame()
	{
		if (protectionTimer >= 1.25f)
		{
			camMov.startGame = true;
			startGameButton.SetActive (false);
			buyShieldButton.SetActive (false);
			buyBoostButton.SetActive (false);
			pMovSc.moveAvaible = true;
			pauseButton.SetActive (true);
		}
	}
	public void buyShield()
	{
		//decrease resources
		if (metalResource >= 20)
		{
			shieldObj.SetActive (true);
			buyShieldButton.SetActive (false);
			for (i = 0; i < 20; i++)
			{
				resManageSc.metalResourceDecrease ();
			}
		}
	}
	public void buyBoost()
	{
		//decrease resources
		if (titaniumResource >= 20)
		{
			boosterObj.SetActive (true);
			buyBoostButton.SetActive (false);
			for (i = 0; i < 20; i++)
			{
				resManageSc.titaniumResourceDecrease ();
			}
		}
	}

	public void goLeaderboard()
	{
		SceneManager.LoadScene ("leaderboard");
	}

	void Start () 
	{
		videoWatch = false;
		protectionTimer = 0f;
	}
	void Update()
	{
		protectionTimer += Time.deltaTime;
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
	}
}
