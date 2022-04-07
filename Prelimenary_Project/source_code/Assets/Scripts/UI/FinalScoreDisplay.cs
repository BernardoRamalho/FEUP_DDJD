using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinalScoreDisplay : MonoBehaviour
{
    private int finalScore;
    public Text scoreText;
    public UnityEngine.UI.Button nextBtn;

    public GameObject finalScoreDisplay;

    void Start(){
        finalScoreDisplay.SetActive(false);
    }
    
    // Start is called before the first frame update
    public void Display(int finalScore)
    {
        GameObject.Find("hud").SetActive(false);

        finalScoreDisplay.SetActive(true);

        Debug.Log(finalScore);

        scoreText.text = "" + finalScore;

		nextBtn.onClick.AddListener(OnClickNext);

    }

    void OnClickNext()
	{
		SceneManager.LoadScene("MenuScene");
	}

}
