using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Controllers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JaneDowController : Character3DPlayer
{

    Animator _anim;
    [SerializeField] Image _1hp;
    [SerializeField] Image _2hp;
    [SerializeField] Image _3hp;
    public int _tapes;
    [SerializeField] TMP_Text _tapeCount;


    protected override void Start() {
        base.Start();

        _tapes = 0;
        _anim = transform.Find("Animations").GetComponent<Animator>();
        

        if (_anim == null)
        {
            Debug.LogError("NO hay componente de animator en el character");
        }
    }

    protected override void Update() {
        base.Update();

        switch (_hp)
        {
            case 3:
                _3hp.enabled = true; _2hp.enabled = false; _1hp.enabled = false;
                break;
            case 2:
                _2hp.enabled = true; _1hp.enabled = false; _3hp.enabled = false;
                break;
            case 1:
                _1hp.enabled = true; _2hp.enabled = false; _3hp.enabled = false;
                break;
            case 0:
                SceneManager.LoadScene("4 Lair On");
                break;
        }

        _tapeCount.SetText(_tapes.ToString() + "/4");

        Vector3 speed = new(_axisH, 0, _axisV);
        _anim.SetFloat("Speed", speed.magnitude);
        /*_anim.SetFloat("Speed", speed.magnitude);
        _anim.SetBool("Fall", _isFalling);
        _anim.SetBool("Grounded", _isGrounded);
        _anim.SetFloat("High", _high);
    
    }

    protected override void StartFall() { 
        base.StartFall();
        _anim.SetTrigger("StartFall");
    
    }

    protected override void Jump()
    {
        base.Jump();
        _anim.SetTrigger("Jump");
    }

    protected override void DetectHigh() {
        base.DetectHigh();
        _high -= 1;
    }

    /*protected override void Punch()
    {
        base.Punch();
        _anim.SetTrigger("Punch");
    }*/

    }
}
