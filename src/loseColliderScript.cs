using UnityEngine;
using System.Collections;
public class LoseCollider : MonoBehaviour {
    
    private LevelManager levelmanager;
    
    void OnCollisionEnter2D(Collision2D collision) {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        levelmanager.LoadLevel("CompWin");
    }
}