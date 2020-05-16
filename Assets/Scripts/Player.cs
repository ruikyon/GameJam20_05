using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float mvSpeed;
    [SerializeField] private GameObject result, clear, over;
    [SerializeField] private TextMeshProUGUI timeText;
    private Rigidbody2D rb;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = GetTime((int)time);
        var dx = Input.GetAxis("Horizontal");
        var dy = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(dx, dy) * mvSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Enemy" || collision.tag == "Dragon")
        {
            // game over
            Destroy(gameObject);
            result.SetActive(true);
            //over.SetActive(true);
            SEManager.Play(SEManager.ClipName.Explode);
            Result.Show(GetTime((int)time), "You Died", false);
        }
        else if (collision.tag == "Finish")
        {
            // clear
            Destroy(gameObject);
            result.SetActive(true);
            //clear.SetActive(true);
            SEManager.Play(SEManager.ClipName.Explode);
            Result.Show(GetTime((int)time), "You Touched\nthe reverse scales!", true);
        }

    }

    private string GetTime(int time) 
    {
        return string.Format("{0:00}",  time / 60) + ":" + string.Format("{0:00}", time % 60);
    }
}
