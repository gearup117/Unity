using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private GameObject instantiateBlock;
    [SerializeField] private GameObject[] instantiateEnemy ;
    private int enemyCount, enemyWaveCount;
    [SerializeField] private int blockCount;
    private Vector2[] spwanPoints;
    [SerializeField] private Vector2 interval;
    // Start is called before the first frame update
    

    void Start()
    {
        Enemy.moveSpeed = 3f;
        spwanPoints = new Vector2[points.Length];
        enemyCount = 5;
        for (int i = 0; i < points.Length; i++) {
            spwanPoints[i] = points[i].transform.position;

        }
        StartCoroutine(spwan());
       StartCoroutine(spwanBlocks());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyCount > enemyWaveCount) {
            Enemy.moveSpeed += 1f;
            enemyCount = 0;
            enemyWaveCount += 3;
            if (interval.x >= 0 && interval.y >= 0)
            {
                interval.x = interval.x - 0.5f;
                interval.y = interval.y - 1f;
                
            }
            else {
                interval = new Vector2(1f, 4f);
            }
        }   
    }
    IEnumerator spwan() {

        while (true)
        {
            if (Random.Range(0, 1f) < 0.2f)
            {
                Instantiate(instantiateEnemy[1], new Vector2(Random.Range(spwanPoints[0].x, spwanPoints[1].x),
                    Random.Range(spwanPoints[0].y, spwanPoints[1].y)), transform.rotation);
            }
            else {
                Instantiate(instantiateEnemy[0], new Vector2(Random.Range(spwanPoints[0].x, spwanPoints[1].x),
                  Random.Range(spwanPoints[0].y, spwanPoints[1].y)), transform.rotation);

            }
           
            enemyCount++;
            yield return new WaitForSeconds(Random.Range(interval.x,interval.y));
        }
        
    }
    IEnumerator spwanBlocks() {
        for (var i = 0; i <= blockCount; i++)
        {
            Instantiate(instantiateBlock, new Vector2(Random.Range(spwanPoints[0].x, spwanPoints[1].x),
            Random.Range(spwanPoints[0].y, spwanPoints[1].y)), transform.rotation);
            yield return new WaitForSeconds(0);
        }
        //yield return new WaitForSeconds(0);
    }
}
