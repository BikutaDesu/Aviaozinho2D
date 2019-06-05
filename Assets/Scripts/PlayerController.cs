using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public GameObject playerParticle;

    public bool gameStarted;
    public bool gameFinished;

    public Vector2 force = new Vector2(0,500f);

    public Text scoreText;
    private int score;


    bool IsGameStarted(){
        return gameStarted;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.transform.position = new Vector2(Screen.width/2, Screen.height - 100);
        scoreText.text = "TOQUE PARA INICIAR";
        scoreText.fontSize = 35;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) && !gameFinished){
            if (!gameStarted)
            {
                gameStarted = true;
                rb2d.isKinematic = false;
                GetComponent<Collider2D>().enabled = true;
            
                scoreText.text = score.ToString();
                scoreText.fontSize = 60;
            }

            rb2d.velocity = new Vector2(0,0);
            rb2d.AddForce(force);
            GameObject playerFeather = Instantiate(playerParticle);
            Vector2 playerPosition = this.transform.position;
            playerPosition += new Vector2(0,1);
            playerFeather.transform.position = playerPosition;
        }

        float playerPositionInPx = Camera.main.WorldToScreenPoint(transform.position).y;
        if(playerPositionInPx + (spriteRenderer.size.y * 2) > Screen.height || playerPositionInPx + (spriteRenderer.size.y * 2) < 0){
            gameFinished = true;
            KillPlayer();
        }    

        transform.rotation = Quaternion.Euler(0,0,rb2d.velocity.y*3);
    }

    void KillPlayer()
    {
        GetComponent<Collider2D>().enabled = false;
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(-300,0));
        rb2d.AddTorque(300f);
        spriteRenderer.color = new Color(1.0f, 0.35f, 0.35f);
        GameOver();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!gameFinished)
        {
            gameFinished = true;
            KillPlayer();
        }    
    }

    void AddScore()
    {
        score+= 10;
        scoreText.text = score.ToString();
    }

    
    void GameOver()
    {
        Invoke("RestartLevel", 2f);
    }

    void RestartLevel(){
        SceneManager.LoadScene("MainScene");
    }
}
