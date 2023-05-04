using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class nv2 : MonoBehaviour
{
	public float tocdo;
	public float jump;
	private float trai_phai;
	private bool isfacingRinght = true;
	private Rigidbody2D rb;
	private Animator anim;
	public bool Onjump;


	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		trai_phai = Input.GetAxis("Horizontal2"); //dichuyentraiphai(a d hoac mũi tên trai phai)
		rb.velocity = new Vector2(trai_phai *-1 * tocdo, rb.velocity.y);
		flip();
		anim.SetFloat("di", Mathf.Abs(trai_phai));

		if (Input.GetKeyDown(KeyCode.I) && Onjump)
		{
			rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
			anim.SetBool("nhay", true);
		}
		else anim.SetBool("nhay", false);

		if (Input.GetKeyDown(KeyCode.K))
		{
			anim.SetBool("da", true);

		}
		else anim.SetBool("da", false);



	}
	void flip()
	{
		if (isfacingRinght && trai_phai < 0 || !isfacingRinght && trai_phai > 0)
		{
			isfacingRinght = !isfacingRinght;
			Vector3 Kich_thuoc = transform.localScale;
			Kich_thuoc.x = Kich_thuoc.x * -1;
			transform.localScale = Kich_thuoc;
		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "menu")
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
	}


}
