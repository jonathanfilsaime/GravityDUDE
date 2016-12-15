using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * this class load the proper scene when a menu item is clicked
 * @Author: Steve Hogue
 */
public class LoadScene : MonoBehaviour {
    private bool loading = false;
    public int scene; //make better
    public Text text; //make better
	public AudioSource openingThemeSong;

    private AsyncOperation async;
	// Use this for initialization
	void Start () {
		openingThemeSong = (AudioSource)gameObject.AddComponent <AudioSource>();
		AudioClip openingClip = (AudioClip)Resources.Load ("Music/01-opening-theme");
		openingThemeSong.clip = openingClip;
		openingThemeSong.loop = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (loading == false) {
			loading = true;
			StartCoroutine (LoadNewScene ());
		} else {
			openingThemeSong.Play ();
		}
	}

    IEnumerator LoadNewScene()
    {
        async = SceneManager.LoadSceneAsync(scene);
        yield return null; //loads when done
    }

    void OnGUI()
    {

    }
}
