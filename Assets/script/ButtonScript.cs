using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string buttonType;

    private void Start()
    {
        switch (buttonType)
        {
            case "start":
                GetComponent<Button>().onClick.AddListener(start);
                break;
            case "exit":
                GetComponent<Button>().onClick.AddListener(exit);
                break;
        }
    }

    void start()
    {
        SceneManager.LoadScene("codeScene");
    }

    void exit()
    {
        Application.Quit();
    }
}
