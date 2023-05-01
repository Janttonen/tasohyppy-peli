using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    // get total score between scenes
    public static int totalScore;
    private TMPro.TextMeshPro txt;



private void Start()
{
    txt = GetComponent<TextMeshPro>();
    txt.text =  "Points collected: " + totalScore;
}

}
