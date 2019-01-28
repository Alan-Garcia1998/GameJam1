using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{

    public float speed;
    public Text scoreText;
    private Rigidbody myRigidbody;
    private int scoreCount;
    private int health;
    public Text healthText;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        scoreCount = 0;
        health = 100;
        scoreText.text = "Score: " + scoreCount;
        healthText.text = "Health: " + health;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        myRigidbody.AddForce(movement * speed);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            scoreCount = scoreCount + 1;

            scoreText.text = "Score: " + scoreCount;
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);

            health = health - 10;

            healthText.text = "Health: " + health;
        }

    }
}
