using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 3;
    private bool isAlive = true;
    private Rigidbody2D rb2d;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        rb2d.velocity = new Vector2(-enemySpeed,0);
        Destroy(this.gameObject, 9f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < player.transform.position.x){
            if(isAlive){
                isAlive = false;
                rb2d.velocity = new Vector2(-7.5f, 5.0f);
                rb2d.isKinematic = false;
                rb2d.AddTorque(-50f);
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);
                player.SendMessage("AddScore");
            }
        }
    }
}
