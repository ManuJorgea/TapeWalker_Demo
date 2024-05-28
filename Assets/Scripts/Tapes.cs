using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapes : MonoBehaviour
{
    JaneDowController janeDowController;
    AudioSource audioSource;
    GameObject tape;
    SphereCollider sphereCollider;
    string tapeLocation;
    private void Start()
    {
        janeDowController = GameObject.Find("PlayerAlison").GetComponent<JaneDowController>();
        audioSource = GetComponent<AudioSource>();
        tapeLocation = gameObject.name + "/TapeObject";
        tape = GameObject.Find(tapeLocation);
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            janeDowController._tapes = janeDowController._tapes + 1;
            audioSource.Play();
            tape.SetActive(false);
            sphereCollider.enabled = false;
        }
    }

}
