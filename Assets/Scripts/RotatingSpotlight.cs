using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpotlight : MonoBehaviour
{
    public GameObject spot;
    private float speed = 2f;
    
    // Update is called once per frame
    void Update()
    {
        spot.transform.Rotate(new Vector3(0,0,speed));
    }
}
