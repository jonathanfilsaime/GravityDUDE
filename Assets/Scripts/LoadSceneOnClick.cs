using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * this class load the proper scene when a menu item is clicked
 * @Author Steve Hogue
 */
public class LoadSceneOnClick : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
