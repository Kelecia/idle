using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public int sceneIndex; // The build index of the scene to load.

    public void ChangeScene()
    {
        SceneManager.LoadScene(1); // Load the scene based on its build index.
    }
}
