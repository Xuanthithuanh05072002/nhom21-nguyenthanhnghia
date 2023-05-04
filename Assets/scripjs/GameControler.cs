using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
	[SerializeField]
	private GameObject pause;
	[SerializeField]
	private Button resumeGame;
	[SerializeField]
	private GameObject End;

	[SerializeField]
	private Button playnow;
	[SerializeField]
	private Button playnow2;
	
	[SerializeField]
	private GameObject nv1;
	[SerializeField]
	private GameObject nv2;
	UIMan m_ui;

	int sc1;
	int sc2;
	int score1 = 1;
	int score2 = 1;
	bool endgame;

	public Transform[] obstacleStart;
	private Transform[] obstacles;
	bool repeatgame = true;

	public AudioSource aus;
	void Start()
	{
		m_ui = FindObjectOfType<UIMan>();
		obstacles = new Transform[obstacleStart.Length];

		for (int i = 0; i < obstacleStart.Length; i++)
		{
			obstacles[i] = Instantiate(obstacleStart[i], obstacleStart[i].position, obstacleStart[i].rotation);
		}
		
	}
	public void SetScore(int valua)
	{
		sc1 = valua;
	}
	public int GetScore()
	{
		return sc1;
	}
	public void UpScore()
	{
		sc1 = score1++;
		m_ui.SetScoreText("" + sc1);
	}
	public void SetScore2(int va)
	{
		sc2 = va;
	}
	public int GetScore2()
	{
		return sc2;
	}
	public void UpScore2()
	{
		sc2 = score2++;
		m_ui.SetScoreText2("" + sc2);
	}

	public bool IsEndgame()
	{
		return endgame;
	}

	public void EndGame()
	{

		// Wait 3 seconds
		repeatgame = false;

		// Reset player position

		// Reset obstacles position
		for (int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].position = obstacleStart[i].position;
		}




	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		pause.SetActive(true);
		resumeGame.onClick.RemoveAllListeners();
		resumeGame.onClick.AddListener(() => ResumeGame());
	}
	public void ResumeGame()
	{
		Time.timeScale = 1;
		pause.SetActive(false);
	}
	
	public void ketthucgame()
	{
		Time.timeScale = 1;
		End.SetActive(false);
		nv1.SetActive(false);
		nv2.SetActive(false);
		if(SceneManager.GetActiveScene().name == "dauluyen") {
			SceneManager.LoadScene("dauluyen");
		}
		if(SceneManager.GetActiveScene().name == "daugiai")
		{
			SceneManager.LoadScene("daugiai");
		}	
	}
	public void Endend()
	{
		if (sc1 == 5) {
			Time.timeScale = 0;
			End.SetActive(true);
			playnow.onClick.RemoveAllListeners();
			playnow.onClick.AddListener(() => ketthucgame());
			playnow2.onClick.RemoveAllListeners();
			playnow2.onClick.AddListener(() => ketthucgame());

		}
		else if (sc2 == 5) {
			Time.timeScale = 0;
			End.SetActive(true);
			playnow.onClick.RemoveAllListeners();
			playnow.onClick.AddListener(() => ketthucgame());
			playnow2.onClick.RemoveAllListeners();
			playnow2.onClick.AddListener(() => ketthucgame());
		}

	}
	public void Hien1()
	{
		if (sc1 == 5)
		{
			Time.timeScale = 0;
			nv1.SetActive(true);
			playnow.onClick.RemoveAllListeners();
			playnow.onClick.AddListener(() => ketthucgame());
			playnow2.onClick.RemoveAllListeners();
			playnow2.onClick.AddListener(() => ketthucgame());
		}
	}
	public void Hien2()
	{
		if (sc2 == 5)
		{
			Time.timeScale = 0;
			nv2.SetActive(true);
			playnow.onClick.RemoveAllListeners();
			playnow.onClick.AddListener(() => ketthucgame());
			playnow2.onClick.RemoveAllListeners();
			playnow2.onClick.AddListener(() => ketthucgame());
		}
	}
	

	public void Menu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("luachon");
	}
	
}
	