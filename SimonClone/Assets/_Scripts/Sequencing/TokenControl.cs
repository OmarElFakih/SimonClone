using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenControl : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed = 0;

    [SerializeField]
    private float _lerpT = 0;

    [SerializeField]
    private int _ids = 0;

    private Animator _animator;



    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void NextWave()
    {
        float _aSpeed = _animator.speed;
        _animator.speed = Mathf.Lerp(_aSpeed, _maxSpeed, _lerpT * Time.deltaTime);

        int _nextID = Random.Range(0, _ids);
        _animator.SetFloat("Blend", (float)_nextID);
    }

}
