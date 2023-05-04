using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class nhanvat2 : MonoBehaviour
{
	
	private Rigidbody2D rb;
	private Animator anim;
	public bool Onjump;
	public float speed;
	public float jumpTime;
	float nextJump = 0f;

	// Start is called before the first frame update
	void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
        // Update is called once per frame
        void Update()
        {
		if (Onjump && Time.time > nextJump)
		{
			nextJump = Time.time + jumpTime;
			Jump();
			anim.SetBool("nhay", true);
		}
		else
			anim.SetBool("nhay", false);
	

}
	void Jump()
	{
		rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if(collision.gameObject.tag=="bong"){
			anim.SetBool("da", true);
		}

		if(collision.gameObject.tag== "menu")
		{
			Onjump = true;
		}
	}
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "menu")
		{
			Onjump = false;
		}
		if (collision.gameObject.tag == "bong")
		{
			anim.SetBool("da", true);
		}
	}
}
