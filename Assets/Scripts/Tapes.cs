using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapes : MonoBehaviour
{
    JaneDowController janeDowController;
    private void Start()
    {
        janeDowController = GameObject.Find("PlayerAlison").GetComponent<JaneDowController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            janeDowController._tapes = janeDowController._tapes + 1;
            this.gameObject.SetActive(false);
        }
    }
}
