using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    
    public void SceneGame()
    {
        SceneManager.LoadScene(0);
    }
    public void SceneHome()
    {
        SceneManager.LoadScene(1);
    }
}
