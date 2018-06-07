using UnityEngine;
using System.Collections;
public class MusicPlayer : MonoBehaviour {
    
    static MusicPlayer instance = null;
    
    void Awake(){        
        if(instance != null){
            Destroy (gameObject);
            print ("duplicate destroyed");
        }else{           
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}