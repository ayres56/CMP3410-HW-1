//Author: Josiah Ayres
//Date: 9/17/2024
//Player Movement / Controller Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Button restartButton;

    private Rigidbody2D rb2d;
    private int count;
    private float timer = 60.0f;

    void Start()
    {
        // Limit framerate to 60fps.
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;


        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        restartButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //Calculate movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;

        //Win condition
        if (timer <= 0.0f)
        {
            winCond();
        }
        else
        {
            //Increment Timer
            timer -= Time.deltaTime;
            int seconds = (int)timer % 60;
            countText.text = "Timer: " + seconds.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp") && timer > 0.0f)
        {
            //Lose the game
            failCond();
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void winCond()
    {
        winText.text = "You Win!";
        restartButton.gameObject.SetActive(true);
    }

    private void failCond()
    {
        winText.text = "You Lose!";
        restartButton.gameObject.SetActive(true);
    }
}
