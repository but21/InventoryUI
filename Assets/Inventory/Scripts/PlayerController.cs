using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 角色刚体组件
    private Rigidbody2D _rigidbody2D;

    // 角色移动速度
    public float speed = 5.0f;

    // 横向输入
    private float _horizontal;

    // 纵向输入
    private float _vertical;

    // 停下来的朝向
    private float _stopX, _stopY;

    // 动画组件
    private Animator _animator;

    // 背包页面
    public GameObject myBag;

    // 判断背包是否打开
    private bool _isOpen;

    private Vector2 _movement;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        SwitchAnim();
        OpenMyBag();
    }

    void Movement()
    {
        // 移动方法一:
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_horizontal, _vertical).normalized;
        _rigidbody2D.velocity = _movement * speed;
    }

    void SwitchAnim()
    {
        // 角色移动和站立动画
        if (_movement != Vector2.zero)
        {
            _animator.SetBool("IsMoving", true);
            _stopX = _horizontal;
            _stopY = _vertical;
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        _animator.SetFloat("InputX", _stopX);
        _animator.SetFloat("InputY", _stopY);
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            /*_isOpen = !_isOpen;
            myBag.SetActive(_isOpen);*/
            myBag.SetActive(!myBag.activeSelf);
        }
    }

    private void FixedUpdate()
    {
        // 移动方法二:
        /*
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(_horizontal, _vertical, 0f);
        transform.position += movement * speed * Time.deltaTime;
        */
    }
}