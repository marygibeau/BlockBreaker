using UnityEngine;
using System.Collections;
public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public AudioClip crack;
    public static int breakableCount = 0;
    public GameObject smoke;
    private LevelManager levelmanager;
    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        breakableCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
        print(breakableCount);
        timesHit = 0;
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //plays clip before brick is destroyed
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable){
            HandleHits();
        }
    }

    void HandleHits(){
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if(timesHit >= maxHits){
            breakableCount--;
            print(breakableCount);
            levelmanager.BrickDestroyed();
            SmokePuff();
            Destroy(gameObject);
        }else{
            LoadSprites();
        }
    }

    private void SmokePuff(){
        Vector3 smokePos = new Vector3(gameObject.transform.position.x,
        gameObject.transform.position.y, 0);
        GameObject smokePuff = Instantiate(smoke, smokePos, Quaternion.identity) as
        GameObject;
        smokePuff.particleSystem.renderer.sortingLayerName = "smokeLayer";
        smokePuff.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, 5f);
    }

    void SimulateWin(){
        levelmanager.LoadNextLevel();
    }

    void LoadSprites(){
        int SpriteIndex = timesHit-1;
        if(hitSprites[SpriteIndex] != null){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
        }else{
            Debug.LogError("Brick sprite missing");
        }
    }
}