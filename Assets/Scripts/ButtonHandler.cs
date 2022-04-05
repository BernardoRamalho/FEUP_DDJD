using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

	public UnityEngine.UI.Button startBtn;

	void Start()
	{
		startBtn.onClick.AddListener(OnClickStart);
	}

	void OnClickStart()
	{
		SceneManager.LoadScene("GameScene");
	}
}
