using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    // current player
    public static GameObject player, otherPlayer;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        } 
        else if (otherPlayer == null)
        {
            otherPlayer = GameObject.FindWithTag("OtherPlayer");
            otherPlayer.SetActive(false);
        }   
    }

    public static void SwitchCharacter(string name)
    {
        switch(name){

            case "Switch":

            name = "Switch";
            // make player inactive
            player.SetActive(false);
        
            player.transform.position = new Vector3(57f,-0.8f,17.70f);
   
            // make player2 active
            otherPlayer.SetActive(true);

            // switch camera to other player
            CameraController.GetTargetByTag("OtherPlayer");
            break;

            case "SwitchBack":

            name = "SwitchBack";

            player.SetActive(true);

            otherPlayer.SetActive(false);

            CameraController.GetTargetByTag("Player");
            break;
        }
        
       
         
    }
  
}
