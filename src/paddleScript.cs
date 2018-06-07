using UnityEngine;
using System.Collections;
public class Paddle : MonoBehaviour {
    
    public bool autoplay = false;
    public Ball ball;

    // Use this for initialization    
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        if(!autoplay){
            MoveWithMouse();
        }else {
            AutoPlay();
        }
    }

    void MoveWithMouse(){
        float mousePosInBlocks = Input.mousePosition.x/Screen.width*16;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.2f, 14.8f);
        this.transform.position = paddlePos;
    }

    void AutoPlay(){
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1.2f, 14.8f);
        this.transform.position = paddlePos;
    }
}