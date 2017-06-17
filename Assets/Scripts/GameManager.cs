using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


	
public class GameManager : Singleton<GameManager>
{

	public GameState currentGameState;
	/*public static GameManager instance;*/

	private float ftimeRemaining;

	public float TimeRemaining {
		get { return ftimeRemaining; }
		set { ftimeRemaining = value; }
	}

	public enum GameState
	{
		MainMenu,
		Gameplay,
		PlayerWin,
		PlayerLose,
		PauseMenu

	}

	public float maxTime = 15 * 60;
	// Seconds in realtime

	void Awake ()
	{
		/*if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}*/
		StartGame ();
		TimeRemaining = maxTime;

	}

	void Update ()
	{
		TimeRemaining -= Time.deltaTime;

		if (TimeRemaining <= 0) {
			SceneManager.LoadScene ("Start");
			TimeRemaining = maxTime;
		}
	}

	//Called to Start Game
	public void StartGame ()
	{
		SetGameState (GameState.Gameplay);
	}

	//Called when end condition is met
	public void GameOver ()
	{

	}

	//Called when player decides to go back to menu
	public void BackToMenu ()
	{

	}

	void SetGameState (GameState newGameState)
	{
		if (newGameState == GameState.MainMenu) {
			//TODO Setup for Main menu Scene
		} else if (newGameState == GameState.PauseMenu) {
			//TODO Setup for Pause menu Scene
		} else if (newGameState == GameState.Gameplay) {
			//TODO Setup for Game Scene
			//TODO Setup for selected Game Scene
		} else if (newGameState == GameState.PlayerLose) {
			//TODO Setup for Lose Scene
		} else if (newGameState == GameState.PlayerWin) {
			//TODO Setup for Win Scene
		}
		currentGameState = newGameState;
       
	}

	void OnGUI ()
	{
		// Make a background box
		GUI.Box (new Rect (10, 10, 100, 90), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect (20, 40, 80, 20), "Start")) {
			SceneManager.LoadScene (1);
		}

		// Make the second button.
		if (GUI.Button (new Rect (20, 70, 80, 20), "Level 2")) {
			SceneManager.LoadScene (2);
		}
	}
}

