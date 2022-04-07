using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Button : MonoBehaviour
{
	void Start()
	{
		UnityEngine.UI.Button btn = gameObject.GetComponent<UnityEngine.UI.Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		Debug.Log("You have clicked the start button!");
	}
}
