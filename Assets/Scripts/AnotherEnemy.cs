using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool right;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Slide());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Slide()
    {
        var flag = right;
        while (true) 
        {
            rb.velocity = Vector3.right * (flag ? -1 : 1) * 3;
            flag = !flag;
            yield return new WaitForSeconds(5);
        }
    }
}
