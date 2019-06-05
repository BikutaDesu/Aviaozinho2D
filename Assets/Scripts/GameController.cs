using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemyPrefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnEnemy", 1, 2f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(){
        if(player.GetComponent<Collider2D>().enabled == true){
            float enemyHeight = 10.0f * Random.value - 5;
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector2(15.0f, enemyHeight);
        }
        
    }
}
