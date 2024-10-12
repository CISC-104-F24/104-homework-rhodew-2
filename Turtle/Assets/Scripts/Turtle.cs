using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{ public string turtleName;
    public float baseTurtleSchmove = 1.0f;
    public Vector3 turtleDirection;
    public float distanceSchmoved;
    public float victoryDistance = 40f;
    public int votesGot;
    public float speedPerVote = 0.4f;
    public KeyCode VoteKey;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(turtleName+" is ready to do some turtling!");
    }

    // Update is called once per frame
    void Update()
    {
        bool isVoteButtonButtoned = Input.GetKeyDown(VoteKey);

        if(isVoteButtonButtoned)
        {
            votesGot = votesGot + 1;
        }

        float turtleStep = (baseTurtleSchmove + votesGot * speedPerVote) * Time.deltaTime;
        transform.position = transform.position + turtleDirection * turtleStep;

        distanceSchmoved = distanceSchmoved + turtleStep;
        //Debug.Log(distanceSchmoved);
        if (distanceSchmoved > victoryDistance)
        {
            Debug.LogWarning(turtleName + " has reached the end! All shall fear it!");
        }
    }
}
