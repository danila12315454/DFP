using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
void OnMouseUpAsButton ()
    {
        switch (gameObject.name)
        {
            case "Levl_0":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Levl_1":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                break; 
            case "Levl_2":
                Debug.Log("2");
                break;
            case "Levl_3":
                Debug.Log("3");
                break;
            case "Levl_4":
                Debug.Log("4");
                break;
            case "Levl_5":
                Debug.Log("5");
                break;
            case "Levl_6":
                Debug.Log("6");
                break;
            case "Levl_7":
                Debug.Log("7");
                break;
            case "Levl_8":
                Debug.Log("8");
                break;
            case "Levl_9":
                Debug.Log("9");
                break;
            case "Levl_10":
                Debug.Log("10");
                break;
            case "Play":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }
}
