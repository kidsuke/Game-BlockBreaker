using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public static int breakableBricksCount = 0;
	private bool isBreakable;
	private int timeHits;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableBricksCount++;
		}
		timeHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		//smoke.GetComponent<ParticleSystem> ().startColor  = this.GetComponent<SpriteRenderer> ().color ;
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.7f);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timeHits++;
		int maxHits = hitSprites.Length + 1; 
		if (timeHits >= maxHits) {
			breakableBricksCount--;
			levelManager.BrickDestroyed ();
			GameObject smokePuff = (GameObject) Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
			smokePuff.particleSystem.startColor  = this.GetComponent<SpriteRenderer> ().color ;
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timeHits - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
