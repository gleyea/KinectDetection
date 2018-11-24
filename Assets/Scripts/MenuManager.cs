using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject freeDetection;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private GameObject explanations;
    [SerializeField]
    private GameObject gestures;
    [SerializeField]
    private GameObject descriptions;
	void Start () {
        Button freeDetectionButton = freeDetection.GetComponent<Button>();
        Button exitButton = exit.GetComponent<Button>();
        Button explanationsButton = explanations.GetComponent<Button>();
        freeDetectionButton.onClick.AddListener(FreeDetection);
        exitButton.onClick.AddListener(ExitWindow);
        explanationsButton.onClick.AddListener(Explanations);
    }

    // Update is called once per frame
    void FreeDetection()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    void ExitWindow()
    {
        Application.Quit();
    }

    void Explanations()
    {
        if (descriptions.activeSelf == true)
        {
            descriptions.SetActive(false);
            gestures.SetActive(true);
        }
        else
        {
            descriptions.SetActive(true);
            gestures.SetActive(false);
        }
    }
    void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
