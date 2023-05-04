using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bóng : MonoBehaviour
{
    private Rigidbody2D rb;
	GameControler m_gc;
	Vector3 lastvelocity;


	public AudioSource aus;
	public AudioClip nay;

	// Start is called before the first frame update
	void Start()
    {
		aus= GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		m_gc=FindObjectOfType<GameControler>();
	}

    // Update is called once per frame
    void Update()
    {
		lastvelocity = rb.velocity;
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var speed = lastvelocity.magnitude;
		var direction = Vector3.Reflect(lastvelocity.normalized, collision.contacts[0].normal);
		rb.velocity = direction * Mathf.Max(speed, 0f);
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("diem")){
			m_gc.UpScore();
			m_gc.EndGame();
			rb.velocity = Vector2.zero;
			m_gc.Endend();
			m_gc.Hien1();
			m_gc.Hien2();
		}
		if (collision.gameObject.CompareTag("menu"))
		{
			if(aus && nay)
			{
				aus.PlayOneShot(nay);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("diem2"))
		{
			m_gc.UpScore2();
			m_gc.EndGame();
			rb.velocity = Vector2.zero;
			m_gc.Endend();
			m_gc.Hien1();
			m_gc.Hien2();


		}
	}
}