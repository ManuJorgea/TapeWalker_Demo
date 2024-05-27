using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] GameObject target;
    void Start()
    {
        target = GameObject.Find("PlayerAlison");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
    }
}
