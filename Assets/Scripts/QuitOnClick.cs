using UnityEngine;
using System.Collections;
/**
 * this class quits the game
 * @Author: Steve Hogue
 */
public class QuitOnClick : MonoBehaviour {

	public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
