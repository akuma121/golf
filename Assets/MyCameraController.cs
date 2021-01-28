using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    private GameObject ball;
    private float ballTransform;
    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("ball");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(ball.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
