using UnityEngine;
using System.Collections;

public class TimedAudio : MonoBehaviour {

    private bool isPlaying = false;
    public float timeOut = 2.0f;

	public void Play()
    {
        if (!isPlaying) { GetComponent<AudioSource>().Play(); StartCoroutine(timedPlay()); }
    }

    IEnumerator timedPlay()
    {
        isPlaying = true;
        yield return new WaitForSeconds(timeOut);
        isPlaying = false;
        StopAllCoroutines();
    }
}
