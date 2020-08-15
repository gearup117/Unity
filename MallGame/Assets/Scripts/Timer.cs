using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float score = 0f;
    private TextMeshProUGUI tm;
    public bool pauseTimer,reachedGate;
    float highScore;
    public TextMeshProUGUI tmHighScore;
    // Start is called before the first frame update
    void Start()
    {
        reachedGate = false;
        pauseTimer = false;
        tm = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat("highScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTimer)
        {
            score += Time.deltaTime;
            tm.text = score.ToString("F3");
        }
        else {
            tm.text = score.ToString("F3");
            
            if(score < highScore && reachedGate)
            {
                highScore = score;
                
                PlayerPrefs.SetFloat("highScore", highScore);

            }
            tmHighScore.text = "HighScore  " + highScore.ToString("F3");
        }
    }
    
}
