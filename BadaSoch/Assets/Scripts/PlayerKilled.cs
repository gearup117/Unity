using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerKilled : MonoBehaviour
{
    public TextMeshProUGUI killedNo, levelNo;
    public Vector3 scaleEnemy;
    public float speed, chaseSpeed;
    public  int zombieKilledNo;
    public  int amountForLevel;
    // Start is called before the first frame update
    void Start()
    {
        scaleEnemy = new Vector3(2f, 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        killedNo.text = zombieKilledNo.ToString();
        levelNo.text = amountForLevel.ToString();
    }
}
