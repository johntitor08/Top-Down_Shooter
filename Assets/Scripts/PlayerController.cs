using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]

    public Rigidbody2D rb;

    public Animator animator;

    [Header("Gameplay")]

    public float speed;

    private int health = 3;

    private Vector2 movement;

    public Text healthText;

    public Text scoreText;

    public static int score;

    float time;


    void Start()
    {
        health = 3;
        score = 0;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (movement.x * speed, movement.y * speed);
        
        runAnim();

        if (health <= 0)
        {
            Die();
        }

        healthText.text = health.ToString();
        scoreText.text = "Score : " + score.ToString();
        
        time += Time.deltaTime;
    }

    private void runAnim()
    {
        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && time > 1)
        {
            health--;
            time = 0;
        }

        if (collision.gameObject.tag == "Life")
        {
            health++;
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
