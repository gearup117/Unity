using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public static  int score;
    [SerializeField ]private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        //tm = GetComponent<TextMeshPro>();
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = score.ToString();
    }
}
