using UnityEngine;
using System.Collections;
public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if(!hasStarted){
            //lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
            //wait for a mouse press to launch
            if(Input.GetMouseButtonDown(0)){
                print ("ball launched");
                this.rigidbody2D.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        //ball doesn't trigger sound when brick is destroyed
        if(hasStarted){
            HandleVelocity();
        }
        audio.Play();
        print(rigidbody2D.velocity);
    }

    void HandleVelocity(){
        Vector2 vtweak;
        if(rigidbody2D.velocity.x >= 0){
            if(rigidbody2D.velocity.y >=0){
                vtweak = new Vector2(Random.Range(0f, 0.1f),
                Random.Range(0f, 0.1f));
            }else{
                vtweak = new Vector2(Random.Range(0f, 0.1f),
                Random.Range(0f, 0.1f));
            }
        }else{
            if(rigidbody2D.velocity.y >=0){
                vtweak = new Vector2(Random.Range(-0.1f, 0f),
                Random.Range(0f, 0.1f));
            }else{
                vtweak = new Vector2(Random.Range(-0.1f, 0f),
                Random.Range(0f, 0.1f));
            }
        }
        Vector2 temp = rigidbody2D.velocity+vtweak;
        rigidbody2D.velocity = new Vector2(Mathf.Clamp(temp.x, -13f, 13f),
        Mathf.Clamp(temp.y, -13, 13));
    }
}