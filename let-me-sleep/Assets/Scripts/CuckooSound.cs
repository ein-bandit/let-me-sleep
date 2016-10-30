using UnityEngine;
using System.Collections;

public class CuckooSound : MonoBehaviour {

    AudioClip[] cuckooSounds = new AudioClip[1];
    AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

        cuckooSounds[0] = Resources.Load("Cuckoo-sound-effect") as AudioClip;

        StartCoroutine(StartSound());

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(0f);

        int playingSoundNumber = Random.Range(0, cuckooSounds.Length);
        audio.PlayOneShot(cuckooSounds[playingSoundNumber], Random.Range(0.1f, 0.4f));
        print(playingSoundNumber);
    }
}
