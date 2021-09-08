using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollRate = 2f;
    [SerializeField] float delayTime = 2f;
    float currTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(currTime < delayTime)
        {
            currTime += Time.deltaTime;
        }
        else
        {
            float yMove = scrollRate * Time.deltaTime;
            transform.Translate(new Vector2(0f, yMove));
        }
    }
}
