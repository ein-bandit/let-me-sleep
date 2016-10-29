using UnityEngine;
using System.Collections;

public class CuckooTimer : MonoBehaviour {

    float spawnTimer; // Time until a cuckoo spawns
    float cuckooTimer; // Time until a cuckoo disappears
    bool hasCuckoo; // clock has currently a cuckoo
    GameObject cuckoo;
    
	// Use this for initialization
	void Start () {
        spawnTimer = Random.Range(2f,6f);
        cuckooTimer = 2f;
        hasCuckoo = false;
	}
	
	// Update is called once per frame
	void Update () {

        // if clock has no cuckoo, then use spawnTimerr
        if(spawnTimer > 0f && !hasCuckoo)
        {
            spawnTimer -= Time.deltaTime;
        }
        
        // if clock has no cuckoo and timer reaches 0, then spawn a cuckoo
        if(spawnTimer <= 0f && !hasCuckoo)
        {
            hasCuckoo = true;
            cuckoo = Instantiate(Resources.Load("Cuckoo-001")) as GameObject; // Instantiate cuckoo
            cuckoo.transform.position = this.gameObject.transform.position; // put cuckoo on position of the clock
            cuckoo.transform.parent = this.gameObject.transform; // add cuckoo as child object of the clock
        }

        // if clock has a cuckoo, then use cuckooTimer
        if(hasCuckoo)
        {
            cuckooTimer -= Time.deltaTime;
            
            // if timer reaches 0, destroy cuckoo
            if(cuckooTimer <= 0f)
            {
                Destroy(cuckoo.gameObject);
            }

            // if cuckoo is destroyed, then reset timers and set bool to false
            if(cuckoo == null)
            {
                cuckooTimer = 2f;
                spawnTimer = Random.Range(2f, 5f);
                hasCuckoo = false;
            }       
        }
	}
}
