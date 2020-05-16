using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < 8; i++) 
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(-7 + 2 * i, 0, 0);
        }
        for (var i = 0; i < 4; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(3, i+1, 0);
        }
        for (var i = 0; i < 4; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(-3, i+1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
