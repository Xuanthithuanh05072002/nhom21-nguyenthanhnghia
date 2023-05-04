using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycha : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Animator enemyAnim;

    public GameObject enemyGraphic;
    bool facingRight = true;
    bool canFlip = true;
    
    void Awake()
    {
        enemyRB=GetComponent<Rigidbody2D>();
        enemyAnim=GetComponentInChildren<Animator>();
    }
    void Flip()
    {
        if (!canFlip)
            return;
        facingRight =!facingRight;
        Vector3 thescale=enemyGraphic.transform.localScale;
        thescale.x *= -1;
        enemyGraphic.transform.localScale= thescale;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
   
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("bong"))
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                Flip();

				enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
				enemyAnim.SetBool("Run", true);

			}
			else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                Flip();
				enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
				enemyAnim.SetBool("Run", true);
			}
            canFlip = false;
        }
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("bong"))
        {
            canFlip = true;
            enemyRB.velocity= new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
	}
}
