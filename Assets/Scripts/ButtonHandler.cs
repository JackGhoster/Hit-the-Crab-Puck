using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour
{
    protected int OfflineSceneId = 1;

    public void OnOfflineButton()
    {
        SceneManager.LoadScene(OfflineSceneId);
    }
}
