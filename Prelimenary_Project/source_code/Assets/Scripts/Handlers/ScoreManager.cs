using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    // Start is called before the first frame update

    public float scoreCount = 0.0f;

    public float pointsPerSecond = 1.0f;

    public bool scoreIncreasing;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount += pointsPerSecond * Time.deltaTime;
        scoreText.text = "" + (int) scoreCount;
    }

    public void addScore(float scoreValue){
        scoreCount += scoreValue;
    }
}
