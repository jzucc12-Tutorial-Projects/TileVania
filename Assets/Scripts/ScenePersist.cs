using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingIndex;

    private void Awake()
    {
        int numSession = FindObjectsOfType<ScenePersist>().Length;
        if(numSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void Start()
    {
        startingIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (startingIndex != SceneManager.GetActiveScene().buildIndex)
            Destroy(gameObject);
    }
}
