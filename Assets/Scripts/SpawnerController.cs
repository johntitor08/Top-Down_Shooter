using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject heartPrefab;

    public Transform[] spawnPoints;

    int heartPossibility;

    float screenBorder;

    public Text timeline;

    float time;


    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, 2f);
        InvokeRepeating("Spawn", 60.5f, 2f);
        InvokeRepeating("Spawn", 120.5f, 2f);
        InvokeRepeating("Spawn", 300.5f, 2f);

        InvokeRepeating("LifeChance", 0.5f, 2f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeline.text = ((int)time).ToString() + "s";
    }

    private void Spawn()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity);

    }

    private void LifeChance()
    {
        heartPossibility = Random.Range(0, 10);

        if (heartPossibility == 7)
        {
            screenBorder = Random.Range(-4.5f, 4.5f);
            GameObject newHeart = Instantiate(heartPrefab, new Vector3(screenBorder, screenBorder), Quaternion.identity);
        }
    }

}
