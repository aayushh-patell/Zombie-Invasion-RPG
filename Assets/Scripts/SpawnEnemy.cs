using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnTime = 1.0f;
    public float time;

    bool update = false;

    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        // Shows Colonel Instructions In Console
        Debug.Log("Soldier, You Have Benn Recruited Here Due To Reports Of A Rogue Invasion, It Is Your Job To Hold Back The Wave Until Recruits Arrive");
        Debug.Log("You Have Been Equipped With 3 Medical Kits For If You Are Attacked By A Rogue, We Believe You Will Do All It Takes To Keep The Rogues At Bay Until Recruits Arrive");

        // Calls Couroutine
        StartCoroutine(enemyWave());

        // Our textBox's value is equal to the value Of Time And We Converrt It To A String To Display 2 Decimal Places
        textBox.text = time.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        // Consistently adds value to time according to time rather than the framerate
        time += Time.deltaTime;

        // Sets our TextBox value to the new value of time
        textBox.text = time.ToString("F2");

        // Makes enemies spawn faster every 20 seconds for upto 180 seconds
        if (time >= 20 && time < 40)
        {
            spawnTime = 0.9f;
        }

        else if (time >= 40 && time < 60)
        {
            spawnTime = 0.8f;
        }

        else if (time >= 60 && time < 80)
        {
            spawnTime = 0.7f;
        }

        else if (time >= 80 && time < 100)
        {
            spawnTime = 0.6f;
        }

        else if (time >= 100 && time < 120)
        {
            spawnTime = 0.5f;
        }

        else if (time >= 120 && time < 140)
        {
            spawnTime = 0.4f;
        }

        else if (time >= 140 && time < 160)
        {
            spawnTime = 0.3f;
        }

        else if (time >= 160 && time < 180)
        {
            spawnTime = 0.2f;
        }

        else if (time >= 180 && time < 200)
        {
            spawnTime = 0.1f;
        }
    }

    private void spawnEnemy()
    {
        // Instantiates Enemy And Moves It To A Random Position Outside The Camera
        GameObject i = Instantiate(enemyPrefab) as GameObject;

        int spawnWhere = UnityEngine.Random.Range(0, 5);

        if (spawnWhere == 1)
        {
            i.transform.position = new Vector2(UnityEngine.Random.Range(-15, -13), UnityEngine.Random.Range(3, -11));
        }

        else if (spawnWhere == 2)
        {
            i.transform.position = new Vector2(UnityEngine.Random.Range(22, -16), UnityEngine.Random.Range(-4, -6));
        }

        else if (spawnWhere == 3)
        {
            i.transform.position = new Vector2(UnityEngine.Random.Range(3, 5), UnityEngine.Random.Range(-17, 9));
        }

        else
        {
            i.transform.position = new Vector2(UnityEngine.Random.Range(14, -24), UnityEngine.Random.Range(-10, -12));
        }
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            // Waits the value of spawnTime in seconds
            yield return new WaitForSeconds(spawnTime);

            // Calls Custom Method
            spawnEnemy();
        }
    }
}
