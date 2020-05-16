using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    private Rigidbody2D rb;
    private float energy = 1;
    [SerializeField] Slider energyBar;
    [SerializeField] GameObject bulletPrefab, pivot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Pendulum());
    }

    // Update is called once per frame
    void Update()
    {
        energy += Time.deltaTime;
        if(energy > 1) 
        {
            energy = 1;
        }
        transform.localPosition = new Vector3(0, 0.5f, 0);
        if (Input.GetButtonDown("Fire1") && energy >= 1) 
        {
            SEManager.Play(SEManager.ClipName.Shot);
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = (pivot.transform.position - transform.position)*5;
            Destroy(bullet, 10);
            energy = 0;
            Debug.Log(transform.forward);
        }
        energyBar.value = energy;
    }

    IEnumerator Pendulum() 
    {
        bool flag = false;
        while (true) 
        {
            rb.angularVelocity = 180 * (flag ? 1 : -1);
            yield return new WaitForSeconds(0.5f);
            transform.localEulerAngles = new Vector3(0, 0, flag ? 45 : -45);
            flag = !flag;
        }
    }
}
