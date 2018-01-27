using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeReset : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
