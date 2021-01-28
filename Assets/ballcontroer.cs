using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballcontroer : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float shotpowerVelocity = 30;
    public float rotSpeed = 0.5f;
    private float visiblePosY = -9.5f;
    private GameObject returnText;
    private GameObject continueText;
    private GameObject goalText;
    private Vector3 lastposition;
    private int hitcounut = 0;
    private GameObject countText;
    public bool isgoal = false; 
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.returnText = GameObject.Find("ReturnText");
        this.continueText = GameObject.Find("ContinueText");
        this.countText = GameObject.Find("CountText");
        this.goalText = GameObject.Find("GoalText");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isgoal == true)
        {
            return;
        }

        if (rigid2D.velocity.y == 0 && rigid2D.velocity.x == 0)
        {
            this.transform.Rotate(0, 0, this.rotSpeed);
            if (Input.GetMouseButtonDown(0))
            {
                lastposition = transform.position;
                this.rigid2D.velocity = transform.up * shotpowerVelocity;
                this.hitcounut += 1;
                this.countText.GetComponent<Text>().text = this.hitcounut + "score";
            }
        }
        if(this.transform.position.y < this.visiblePosY)
        {
            this.continueText.GetComponent<Text>().text = "[C] Continue";
            if (Input.GetKey(KeyCode.C))
            {
                SceneManager.LoadScene("SampleScene");
            }

            this.returnText.GetComponent<Text>().text = "[R] Return ";
            if(Input.GetKey(KeyCode.R))
            {
                transform.position = lastposition;
                this.rigid2D.velocity = new Vector3(0, 0, 0);
                this.rigid2D.angularVelocity = 0;
                this.returnText.GetComponent<Text>().text = "";
                this.continueText.GetComponent<Text>().text = "";
            }

            

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Goal" )
        {
            if(this.rigid2D.velocity.y == 0 && this.rigid2D.velocity.x == 0)
            {
                this.isgoal = true;
                this.goalText.GetComponent<Text>().text = "GOAL";
            }
            
        }
    }
}
