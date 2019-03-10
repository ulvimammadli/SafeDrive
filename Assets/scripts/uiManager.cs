using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public static uiManager instance;
    public Button[] buttons;
    public Text scoreText;
    public Text levelText;
    public AudioManager am;
    bool gameOver;
    double score = 0;
    double coefficient = 1.0;
    bool one = false, two = false, three = false, four = false, five = false;

    void Start()
    {
        instance = this;
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    void FixedUpdate()
    {
        scoreText.text = "Score: " + System.Convert.ToInt32(score);
        handleLevels();
    }

    public void speedUp()
    {
        coefficient += 0.1;
    }

    public void speedDown()
    {
        if (coefficient > 1)
        {
            coefficient -= 0.1;
        }
    }

    public float getScore()
    {
        return (float)score;
    }

    public void scoreUpdate()
    {
        if (gameOver == false)
        {
            score += (1 * coefficient);
        }
    }

    public bool protiv()
    {
        if (gameOver == false)
        {
            score -= (0.1 * coefficient);
            if (score <= 0)
            {
                return true;
            }
        }

        return false;
    }

    public bool level1()
    {
        if (!one)
        {
            if (score / 100 >= 0) {
                one = !one;
                return (score / 100) >= 0;
            }
        }

        return false;
    }

    public bool level2()
    {
        if (!two)
        {
            if (score / 100 >= 1)
            {
                two = !two;
                return (score / 100) >= 1;
            }
        }

        return false;
    }

    public bool level3()
    {
        if (!three)
        {
            if (score / 100 >= 2)
            {
                three = !three;
                return (score / 100) >= 2;
            }
        }

        return false;
    }

    public bool level4()
    {
        if (!four)
        {
            if (score / 100 >= 3) {
                four = !four;
                return (score / 100) >= 3;
            }
        }

        return false;
    }

    public bool level5()
    {
        if (!five)
        {
            if (score / 100 >= 4)
            {
                five = !five;
                return (score / 100) >= 4;
            }
        }

        return false;
    }

    public void handleLevels()
    {
        if (level1())
        {
            levelText.text = "Level: 1";
        }

        if (level2()){
            levelText.text = "Level: 2";
        }

        if (level3())
        {
            levelText.text = "Level: 3";
        }

        if (level4())
        {
            levelText.text = "Level: 4";
        }

        if (level5())
        {
            levelText.text = "Level: 5";
        }
    }

    public void mute()
    {
        AudioListener.pause = true;
        
    }

    public void play()
    {
        AudioListener.pause = false;
    }

    public void gameOverAction()
    {
        gameOver = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        Application.LoadLevel("SampleScene");
    }

    public void Settings()
    {
        Application.LoadLevel("setScene");
    }

    public void howto()
    {
        Application.LoadLevel("howtoScene");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            am.carSound.Stop();
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            am.carSound.Play();
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {
        Application.LoadLevel("menuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
