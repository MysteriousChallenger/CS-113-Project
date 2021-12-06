using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour {
    public Object scene; // actually of type Scene

    public void ChooseLevel() {
        SceneManager.LoadScene(scene.name);
    }
}