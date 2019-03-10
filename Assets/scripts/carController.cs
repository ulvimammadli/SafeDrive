using UnityEngine;
using System.Collections;
using UnityEditor;

public class carController : MonoBehaviour
{
    public float carSpeed = 0f;
    public float maxPos = 5.0f;
    public bool pause = false;
    public float time_scale = 0;
    Vector3 position;
    public bool turnedRight = false, turnedLeft = false;
    public uiManager ui;
    public AudioManager am;

    void Awake()
    {
        am.carSound.Play();
    }

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        if (uiManager.instance.getScore() >= 500)
        {
            Destroy(gameObject);
            am.carSound.Stop();
            carSpeed = 0f;
            Time.timeScale = 1;
            trackMove.instance.resetSpeed();
            Application.LoadLevel("wonScene");
            //GUI.TextField(new Rect(10, 10, 200, 20), "Congratulations! You won!", 25);
            //MessageBox.Show("Safe Drive", "Congratulations! You won!", MessageBoxButtons.OK);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Time.timeScale += 0.01f;
            trackMove.instance.speed += 0.025f;
            uiManager.instance.speedUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Time.timeScale - 0.025f > 0)
            {
                trackMove.instance.speed += 0.025f;
                Time.timeScale -= 0.01f;
                uiManager.instance.speedUp();
            }
        }

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -5.0f, 5.0f);

        if (position.x < 0 || position.x > 4.3)
        {
            bool over = uiManager.instance.protiv();
            if (over)
            {
                gameOver();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!turnedLeft && !turnedRight)
            {
                transform.Rotate(0, 0, 20);
                turnedLeft = true;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!turnedRight && !turnedLeft)
            {
                transform.Rotate(0, 0, -20);
                turnedRight = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -20);
            turnedLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, 20);
            turnedRight = false;
        }

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Opposite Car")
        {
            gameOver();
        }
    }

    void gameOver()
    {
        Destroy(gameObject);
        ui.gameOverAction();
        am.carSound.Stop();
        carSpeed = 0f;
        Time.timeScale = 1;
        trackMove.instance.resetSpeed();
    }
}