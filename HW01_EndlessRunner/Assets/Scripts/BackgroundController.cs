using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    //Followed tutorial for background
    public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //The background image is set to "Repeat" so that it actually repeats the same image
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the background in a downward looking motion at a rate of "speed"
        bgRenderer.material.mainTextureOffset += new Vector2(0, (speed * Time.deltaTime) / 10);
    }
}