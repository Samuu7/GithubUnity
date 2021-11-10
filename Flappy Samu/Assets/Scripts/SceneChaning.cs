using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChaning : MonoBehaviour
{


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hola")
        {
            SceneManager.LoadScene("SecondScene");
        }
    }
}
