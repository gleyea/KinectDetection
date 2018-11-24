using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour {

    [SerializeField]
    private GameObject kinectPrefab;
    [SerializeField]
    private GameObject kinectPointMan;
    public void Return()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        GameObject.Destroy(kinectPrefab);
        GameObject.Destroy(kinectPointMan);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            GameObject.Destroy(kinectPrefab);
            GameObject.Destroy(kinectPointMan);
        }
    }
}
