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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();
            if(count >= 2)
            {
                winText.text = "You Win!";
                restartButton.gameObject.SetActive(true);
            }
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
