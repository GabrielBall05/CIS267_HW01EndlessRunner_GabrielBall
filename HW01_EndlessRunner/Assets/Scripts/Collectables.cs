using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private Rigidbody2D collectableRigidBody;
    public int collectableValue;
    public int fallingSpeed;

    void Start()
    {
        collectableRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Fall at constant speed (fallingSpeed determined in Unity editor)
        transform.position -= transform.up * Time.deltaTime * fallingSpeed;
        //Collectable value is also determined via Unity editor
    }

    public int getCollectableWeightedValue()
    {
        //Get the time from GameManager
        int time = (int)GetComponent<GameManager>().getTime();
        //Basic lil formula, might change later
        int weightedValue = (collectableValue + (time * 2)); //Will get multiplied by numCollectablesCollected anyway on the Player side

        return weightedValue;
    }
}