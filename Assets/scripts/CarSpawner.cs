using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    private const float maxRangeOfRandom = 0.5f;
    private const float coefficient = 0.15f;
    public GameObject[] cars;
    int carNo;
    public float maxPos = 3.5f;
    public float delayTimer = 1f;
    float timer;
    int counter = 0;
    int rCounter = 0;

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
            spawnMyCar();
            timer = delayTimer;
        }
    }

    void spawnMyCar()
    {
        if (counter == 0)
        {
            float spawnY = maxRangeOfRandom - (coefficient * (uiManager.instance.getScore() / 100));
            Vector3 carPos = new Vector3(Random.Range(3.5f, 1.5f), Random.Range(0.0f, spawnY), transform.position.z);
            carNo = Random.Range(0, cars.Length);
            Object go = cars[System.Math.Min(carNo, cars.Length - 1)];
            Instantiate(go, transform.position, transform.rotation);
            counter = Random.Range(0, 5 - (int) uiManager.instance.getScore() / 100);

        }
        else
        {
            counter--;
        }
    }

}
