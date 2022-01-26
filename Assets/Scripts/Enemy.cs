using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text myText;
    public GameObject restartButton;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            myText.text = "GameOver";
            restartButton.SetActive(true);
            if (Input.anyKeyDown)
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        myText.text = "";
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
