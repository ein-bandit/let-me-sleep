using UnityEngine;
using System.Collections;

public class clockSound : MonoBehaviour {

    AudioClip[] clockSounds = new AudioClip[2];
    AudioSource audio;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();

        clockSounds[0] = Resources.Load("Ticking-noise") as AudioClip;
        clockSounds[1] = Resources.Load("Ticking-clock-sound") as AudioClip;

        StartCoroutine(StartSound());

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(1f);

        int playingSoundNumber = Random.Range(0, clockSounds.Length);
        audio.PlayOneShot(clockSounds[playingSoundNumber], 0.5f);
        print(playingSoundNumber);
    }
}
