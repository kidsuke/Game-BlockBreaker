using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	private static MusicPlayer INSTANCE;

	void Awake () {
		Debug.Log ("Music player awake " + GetInstanceID ());
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Music player awake " + GetInstanceID ());
		if (INSTANCE != null) {
			Destroy (gameObject);
		} else {
			INSTANCE = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
