using UnityEngine;
using System.Collections;

public class CuckooTimer : MonoBehaviour {

    float spawnTimer;
    bool hasCuckoo;
    GameObject cuckoo;
    
	// Use this for initialization
	void Start () {
        spawnTimer = Random.Range(2f,6f);
        hasCuckoo = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(spawnTimer > 0f && !hasCuckoo)
        {
            spawnTimer -= Time.deltaTime;
        }
        

        if(spawnTimer <= 0f && !hasCuckoo)
        {
            hasCuckoo = true;
            cuckoo = Instantiate(Resources.Load("Cuckoo-001")) as GameObject;
            cuckoo.transform.position = this.gameObject.transform.position;
            cuckoo.transform.parent = this.gameObject.transform;
        }

        if(hasCuckoo && cuckoo==null)
        {
            spawnTimer = Random.Range(2f, 6f);
            hasCuckoo = false;
        }
	}
}
