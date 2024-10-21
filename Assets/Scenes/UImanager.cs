using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRematch()
    {
        SceneManager.LoadScene("Battle Arena Main 2 Greenscreen");
    }

    public void OnExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
