using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // startPoints are all points the player is colleting in the game
    private int startPoints;
    private Animator animator;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    private void Start()
    {
        startPoints = ScoreCounter.totalScore;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player collides with object tagged "Trap"
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if(collision.gameObject.CompareTag("DeathGround"))
        {
            if (GameObject.FindWithTag("Player") == true)
            {
               Die(); 
            }
            
        }
    }

    private void Die()
    {
        animator.SetTrigger("death");
        // when player dies, rigidbody changes to static -> player cannot move
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        // set counter back to same number when player started level
        ScoreCounter.totalScore = startPoints;
        // reload to current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
