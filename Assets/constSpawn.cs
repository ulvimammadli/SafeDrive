using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constSpawn : MonoBehaviour {

	private const float maxRangeOfRandom = 0.75f;
    private const float coefficient = 0.25f;
    public GameObject[] con_sign;
    int carNo;
    public float maxPos = 3.5f;
    public float delayTimer = 1f;
    float timer;
    int counter = 0;

    void Start()
    {
        timer = delayTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timer <= 0)
        {
            spawnMyConSign();
            timer = delayTimer;
        }
    }

    void spawnMyConSign()
    {
        if (counter == 0)
        {
            float spawnY = maxRangeOfRandom - (coefficient * (uiManager.instance.getScore() / 100));
            Vector3 carPos = new Vector3(Random.Range(3.5f, 1.5f), Random.Range(0.0f, spawnY), transform.position.z);
            carNo = Random.Range(0, con_sign.Length - 1);
            Instantiate(con_sign[System.Math.Max(carNo, con_sign.Length) - 1], transform.position, transform.rotation);
            counter = Random.Range(0, 10);
        }
        else
        {
            counter--;
        }
    }
}
