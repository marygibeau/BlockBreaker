using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour {
    
    public void LoadLevel(string name){
        Debug.Log("Level load requested for " + name);
        Application.LoadLevel(name);
    }
    
    public void QuitRequest(){
        Debug.Log("quit");
        Application.Quit();
    }
    
    public void LoadNextLevel(){
        Application.LoadLevel(Application.loadedLevel+1);
    }
    
    public void BrickDestroyed(){
        if(Brick.breakableCount <= 0){
            LoadNextLevel();
        }
    }
}