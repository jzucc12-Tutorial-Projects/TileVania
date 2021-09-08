using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float exitDelay = 1f;
    [SerializeField] float slowMo = 0.333f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ExitLevel());

    }
    IEnumerator ExitLevel()
    {
        Time.timeScale = slowMo;
        yield return new WaitForSeconds(exitDelay);
        Time.timeScale = 1;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
