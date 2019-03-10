using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class trackMove : MonoBehaviour
{
    public static trackMove instance;
    public float speed = 1.5f;
    Vector2 offset;

    void Start()
    {
        instance = this;
        // for future updates
        #if UNITY_ANDROID
		    speed = 0.5f;
        #endif

        #if UNITY_STANDALONE_WIN
            speed = 1.5f;
        #endif
    }

    public void resetSpeed()
    {
        speed = 1.5f;
    }

    public void increaseSpeed()
    {
        speed += 0.25f;
    }

    public void decreaseSpeed()
    {
        speed -= 0.25f;
    }

    void Update()
    {
        offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
