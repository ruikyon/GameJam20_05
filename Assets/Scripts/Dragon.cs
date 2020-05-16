using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rand = Random.Range(0, 1f);
        var deg = 0;
        if(rand < 0.25) 
        {
            deg = -607;
        }
        else if(rand < 0.5)
        {
            deg = -360;
        }
        else if(rand < 0.75)
        {
            deg = 360;
        }
        else 
        {
            deg = 607;
        }


        transform.parent.GetComponent<Rigidbody2D>().angularVelocity = deg;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
