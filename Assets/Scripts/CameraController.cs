using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // https://forum.unity.com/threads/camera-that-target-gameobject-with-tag-player.324371/
    public static Transform player;
    private void Start()
    {
        GetTargetByTag("Player");
    }
    // track player with camera
    // create field to Unity, so you can drag and drop Player component to this

    private void Update()
    {

        if (player)
        {
            // Vector 3, because cameras location is in 3D space
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

    }

    public static void ChangeTarget(Transform target)
    {
        player =  target;
    }

    public static void GetTargetByTag(string tag)
    {
        GameObject obj = GameObject.FindWithTag(tag);
        if (obj)
        {
            ChangeTarget(obj.transform);
        }
        else
        {
            Debug.Log("Cant find object with tag " + tag);
        }
    }
}
