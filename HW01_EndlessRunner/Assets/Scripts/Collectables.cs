using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private Rigidbody2D collectableRigidBody;
    public int collectableValue;
    public int fallingSpeed;

    //Add GameManager.cs as a component to all collectables so that they can access its .getTime() function

    void Start()
    {
        collectableRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hasCollectableHitGround();
        //Fall at constant speed (fallingSpeed determined in Unity editor)
        transform.position -= transform.up * Time.deltaTime * fallingSpeed;
        //Collectable value is also determined via Unity editor
    }

    public void destroyCollectable()
    {
        Destroy(this.gameObject);
    }

    public int getCollectableValue()
    {
        return collectableValue;
    }

    public void setCollectableValue(int val)
    {
        collectableValue = val;
    }

    public int getCollectableWeightedValue()
    {
        //Get the time from GameManager
        int time = (int)GetComponent<GameManager>().getTime();
        //Basic lil formula, might change later
        int weightedValue = (collectableValue + time);

        return weightedValue;
    }

    private void hasCollectableHitGround()
    {
        if (collectableRigidBody.position.y <= -5.242)
        {
            //Debug.Log("Collectable Hit Floor");
            destroyCollectable();
        }
    }

}
