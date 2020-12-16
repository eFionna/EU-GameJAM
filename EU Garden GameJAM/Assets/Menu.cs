using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Quit();
        }
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
