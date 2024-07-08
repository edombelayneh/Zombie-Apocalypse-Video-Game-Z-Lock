using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimatorNew : MonoBehaviour
{
    [SerializeField]
    private Sprite[] frameArray;
    private int currentFrame;
    private float timer;


    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            timer -= 1f;
            currentFrame++;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[currentFrame];
        }
    }
}
