using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    RollSnow rollSnow;
    [SerializeField] LayerMask layer;
    private Transform _player;
    [SerializeField] public float speed;
    private Animator _anim;
    RaycastHit hit;
    private void Start()
    {
        rollSnow = GetComponent<RollSnow>();
        _player = transform.GetChild(0);
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (rollSnow.isFall)
            return;
        Physics.Raycast(_player.position + _player.forward / 3 + _player.transform.up, -_player.up,out hit, 100 , layer);
        Debug.DrawRay(_player.position + _player.forward /3+ _player.transform.up, -_player.up * 5);
        if(MyJoystick.instance.moved)
        {
            if(hit.collider != null)
            {
                transform.position += (Vector3.right * MyJoystick.instance.dir.x + Vector3.forward * MyJoystick.instance.dir.y) * (Time.deltaTime * speed);

            }
            transform.forward = new Vector3(MyJoystick.instance.dir.x, 0, MyJoystick.instance.dir.y) * (Time.deltaTime * speed);
            _anim.SetBool("Run", true);
            _anim.SetBool("Idle", false);
        }
        else
        {
            _anim.SetBool("Run", false);
            _anim.SetBool("Idle", true);
            
        }
    }
}
