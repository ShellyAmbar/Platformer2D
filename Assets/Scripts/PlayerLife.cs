using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]private int lifeCount = 50;
    private int maxLevelHits = 3;
    private int playerHits = 0;
    private Animator anim;
    private Rigidbody2D rb;
    private enum Obstecales
    {
        Trap,
       

    }
    private enum PlayerStatus
    {
        Level_Death,
        Hit,
        Total_Death
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Enum.GetName(typeof(Obstecales), Obstecales.Trap)))
        {
            onPlayerHit();
        }
        
    }

    private void onPlayerHit()
    {

        lifeCount--;
        playerHits++;
        Debug.Log("lifeCount " + lifeCount + " Hits: " + playerHits);
       
       
        if (lifeCount == 0) {
            rb.bodyType = RigidbodyType2D.Static;
            playerHits = 0;
            anim.SetTrigger(Enum.GetName(typeof(PlayerStatus), PlayerStatus.Total_Death).ToLower());          
            
           
        }
        else if(playerHits == maxLevelHits)
        {
            //restart this level
            rb.bodyType = RigidbodyType2D.Static;
            playerHits = 0;
            anim.SetTrigger(Enum.GetName(typeof(PlayerStatus), PlayerStatus.Level_Death).ToLower());
            
        }
        else
        {
            // animate hit
            anim.SetTrigger(Enum.GetName(typeof(PlayerStatus), PlayerStatus.Hit).ToLower());
        }

        

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void RestartFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

}
