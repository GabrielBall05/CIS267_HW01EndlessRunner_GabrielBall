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
        //stops gravity and acceleration
        collectableRigidBody.isKinematic = true;
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

    private void hasCollectableHitGround()
    {
        if (collectableRigidBody.position.y <= -5.242)
        {
            Debug.Log("Collectable Hit Floor");
            destroyCollectable();
        }
    }

}
