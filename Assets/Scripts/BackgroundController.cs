using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    
    float screenWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        float screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight/Screen.height*Screen.width;
        
        float backgroundWidth = spriteRenderer.sprite.bounds.size.x;
        float backgroundHeight = spriteRenderer.sprite.bounds.size.y;

        Vector2 newScale = transform.localScale;
        newScale.x = screenWidth/backgroundWidth + 0.25f;
        newScale.y = screenHeight/backgroundHeight;
        this.transform.localScale = newScale;

        if(this.name == "BackgroundB"){
            transform.position = new Vector2(screenWidth, 0f);
        }

        rb2d.velocity = new Vector2(-3,0);            
    }

    void Update()
    {
        if(transform.position.x <= -screenWidth){
            transform.position = new Vector2(screenWidth, 0f);
        }    
    }
}
