using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

	public UnityEngine.UI.Button startBtn;
	public UnityEngine.UI.Button exitBtn;

	void Start()
	{
		startBtn.onClick.AddListener(OnClickStart);
		exitBtn.onClick.AddListener(OnClickExit);
		
	}

	void OnClickStart()
	{
		SceneManager.LoadScene("GameScene");
	}

	void OnClickExit()
	{
		Application.Quit();
	}
}
