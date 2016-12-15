using UnityEngine;
using System.Collections;

/**
 * this class handles the collision detection between the player and the coins
 * once the player hits the coin, the coin dissapears and the score is incremented
 * @Author: Jonathan Fils-Aime 
 */
public class CoinBehavior : MonoBehaviour 
{
	int i = 0;
	public WorldController wc;
	public GameObject CoinCollect;
	public AudioSource CoinSound;



	public void OnTriggerEnter(Collider other)
	{
		CoinCollect = GameObject.FindGameObjectWithTag("coinCollected");
		CoinSound = CoinCollect.GetComponent<AudioSource> ();
		CoinSound.Play ();
		UIController wc = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
		i++;
		wc.score += i;
		Destroy (this.gameObject);
	}

    public void Update() {
        this.transform.Rotate(Vector3.back, 60 * Time.deltaTime, Space.Self);
    }
}
