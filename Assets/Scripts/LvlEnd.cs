using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlEnd : MonoBehaviour
{
    JaneDowController janeDowController;
    private void Start()
    {
        janeDowController = GameObject.Find("PlayerAlison").GetComponent<JaneDowController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (janeDowController._tapes == 4)
        {
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
        }
    }
}
