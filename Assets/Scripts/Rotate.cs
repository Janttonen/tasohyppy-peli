using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Make objects to rotate
   [SerializeField] private float speed = 2f;
    private void Update()
    {
        // x, y and z values
        // only roteta z value, 360 degrees
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
