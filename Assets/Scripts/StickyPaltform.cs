using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPaltform : MonoBehaviour
{

    // platform has two box colliders, top one is triggered when collision happens
    // get notification if player touches platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision happens with gameobject named "player"
        if (collision.CompareTag("Player"))
        {
            // set Player as child component of this moving platform
            // as a childcomponent player moves with a platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // when player doesn't touch platform anymore
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // remove Player as child component of this moving platform
            collision.gameObject.transform.SetParent(null);
        }
    }

}
