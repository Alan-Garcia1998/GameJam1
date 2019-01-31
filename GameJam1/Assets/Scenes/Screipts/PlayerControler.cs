using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody myRigidBody;
    public bool fltouch;
    private int scoreCount;
    public float speed;
    public float boostTime;
    public Text scoreText;
    public Text timeText;
    private bool timer;
    public bool pressed = false;
    public float boost = 10;
    public float gameTime = 15;
    float offAir = 2.0f;
    public int lives;
    public float ypos = -20.0f;
    Vector3 jump = new Vector3(0.0f, 2f, 0.0f);
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        render = GetComponent<Renderer>();
        myRigidBody = GetComponent<Rigidbody>();
        scoreCount = 0;
        scoreText.text = "Score: " + scoreCount;
        timeText.text = "Time: " + gameTime;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        myRigidBody.AddForce(movement * speed);

        if (transform.position.y < ypos)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            lives --;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        fltouch = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Quits the game after pushing escape
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space) && fltouch)
        {
            myRigidBody.AddForce(jump * offAir, ForceMode.Impulse);
            fltouch = false;
        }
        if (lives >= 3)
        {
            lives = 3;
            render.material.color = new Color(0, 1, 0, 0);
        }
        else if (lives == 2)
        {
            render.material.color = Color.yellow;
        }
        else if (lives == 1)
        {
            render.material.color = Color.red;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        timeText.text = "Time: " + gameTime;
        /*
        if ((Input.GetKeyDown("space")) && (pressed = false))
        {
            pressed = true;
            speed = speed * 4;
            boostTime = 5;
            timer = true;
            
        }
        */

        if (timer == true)
        {
            boostTime -= Time.deltaTime;
        }

        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            Application.LoadLevel(0);
        }

        if (boostTime <= 0)
        {
            timer = false;
            speed = 10;
            boostTime = 0.5f;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            scoreCount++;
            scoreText.text = "Score: " + scoreCount;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives--;
        }
        if (other.gameObject.CompareTag("Health"))
        {
            other.gameObject.SetActive(false);
            lives++;
        }
        if (other.gameObject.CompareTag("Boost"))
        {
            other.gameObject.SetActive(false);
            speed = speed * boost;
            timer = true;
        }

    }
}