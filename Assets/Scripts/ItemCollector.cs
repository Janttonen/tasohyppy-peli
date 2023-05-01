using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text counterText;

    private void Start()
    {
        if(counterText)
        {
            counterText.text = "Points: " + ScoreCounter.totalScore;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check game objects tag (melon, player, respawn, finish etc)
        if (collision.gameObject.CompareTag("Melon"))
        {
            // remove object from game
            // also removes object from scene hierarchy
            // add points to counter
            Destroy(collision.gameObject);
            ScoreCounter.totalScore = ScoreCounter.totalScore + 1;
            counterText.text = "Points: " + ScoreCounter.totalScore;
        }

        if (collision.gameObject.CompareTag("SuperFruit"))
        {
            if (GameObject.FindWithTag("Player"))
            {
                Destroy(collision.gameObject);
                SwitchCharacters.SwitchCharacter("Switch");
            }

        }

        if (collision.gameObject.CompareTag("BoringFruit"))
        {
            if (GameObject.FindWithTag("OtherPlayer"))
            {
                Destroy(collision.gameObject);
                SwitchCharacters.SwitchCharacter("SwitchBack");
            }
        }
    }

}
