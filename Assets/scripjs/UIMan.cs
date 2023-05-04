using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : MonoBehaviour
{
    public Text scoreText;

    public Text scoreText2;

   

    
    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }
	public void SetScoreText2(string txt)
	{
		if (scoreText2)
		{
			scoreText2.text = txt;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
