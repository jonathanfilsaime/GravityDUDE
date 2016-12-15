using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * this class handles the player interaction and player state
 * by pressing spacebar the gravity is inverted 
 * if the player has a y position of 30 or -30 without collecting 25 coins 
 * the player is dead and loses. If the player collects 25 coins before dying 
 * then the plyer wins
 * @Author Jonathan Fils-Aime, Steve Hogue 
 */
public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool isUp = false;
	[HideInInspector]
	public bool isDown = false;

	public float gravity;
	public float speed;
	public float maxSpeed;
    public Text deathText;
    public Text continueText;
	public Text finalScoreText;

	private Animator anim;
	private Rigidbody rb;
	private Collider coll;
	private CharacterController controller;

	public Vector3 moveDirection = Vector3.zero;
	public float verticalSpeed = 0;
    private bool dead = false;

	public AudioSource playSong;
	public AudioSource winSong;
	public AudioSource deathSong;


	void Awake() {
		//coll = GetComponent<Collider>();
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
	}

	// Use this for initialization
	void Start() {
        this.deathText.enabled = false;
        this.continueText.enabled = false;
		this.finalScoreText.enabled = false;
		playSong.Play ();
	


	}

	// Update is called once per frame
	void Update() {
        if (this.dead) {
        } else {
			
            if (Input.GetKeyDown(KeyCode.Space) && (this.isUp || this.isDown)) // change to "Reverse"
            {
                this.isUp = false;
                this.isDown = false;
                Flip();
            }

            moveDirection = Vector3.right;
			verticalSpeed -= gravity * Time.deltaTime;

            // if speed > 0
            // line cast up
            // else if speed < 0
            // line cast down
            if (verticalSpeed > 0) {
                if (Physics.Linecast(this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(0, 0.6f, 0))) {
                    this.isUp = true;
                    verticalSpeed = 0;
                }
                else {
                    this.isUp = false;
                }
            }
            else if (verticalSpeed < 0) {
                if (Physics.Linecast(this.gameObject.transform.position, this.gameObject.transform.position - new Vector3(0, 0.6f, 0))) {
                    this.isDown = true;
                    verticalSpeed = 0;
                }
                else {
                    this.isDown = false;
                }
            }

            moveDirection *= speed;
            moveDirection.y = verticalSpeed;
            controller.Move(moveDirection * Time.deltaTime);

			if (this.moveDirection.y > 50 || this.moveDirection.y < -50) {
				playSong.mute = true;
                this.Kill();

            }
        }
    }

	void FixedUpdate() {

	}

	void Flip() {
		this.gravity = -this.gravity;
		GetComponent<SpriteRenderer> ().flipY = !GetComponent<SpriteRenderer> ().flipY;
	}

    void Kill() {
        this.dead = true;
		this.continueText.text = "Press <Enter> to Continue";
		this.continueText.enabled = true;
		playSong.Stop ();

		UIController wc = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
		if (wc.score > 24) 
		{
			this.finalScoreText.text = "Score: " + wc.score;
			this.deathText.text = "You Win";
			winSong.Play ();

		} 
		else 
		{
			this.finalScoreText.text = "Score: " + wc.score;
			this.deathText.text = "Game Over";
			deathSong.Play ();
		}

		this.deathText.enabled = true;
		this.finalScoreText.enabled = true;
        StartCoroutine("LoadAfterDeath");
    }

    IEnumerator LoadAfterDeath() {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        SceneManager.LoadScene("MainMenu");
    }
}