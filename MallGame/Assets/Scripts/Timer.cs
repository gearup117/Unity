using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float a = 0f;
    private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        tm.text = a.ToString("F3");
    }
}
