using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrul : MonoBehaviour
{
    public float Mspeed;
    private bool moovingRight = true;
    public Transform groundDetection;
    public float Distance;

    private void Update()
    {
        transform.Translate(Vector2.left * Mspeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, Distance);

        if(groundInfo.collider == false)
        {
            if(moovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moovingRight = true;
            }
        }
    }
}
