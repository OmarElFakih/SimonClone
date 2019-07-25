using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private AudioMixerSnapshot[] _snapshots = null;//used for audio transitions

    private int _index = 0;//used to select the corresponding snapshot

    [SerializeField]
    private float _initialSpeed = 0;//initial speed of tokens

    [SerializeField]
    private float _maxSpeed = 0;//max speed of tokens

    private float _currentSpeedSave = 0;//used to return to the last saved speed after a slowdown

    [SerializeField]
    private float _lerpT = 0;//used to lerp the tokens` speed

    [SerializeField]
    private int _consecutiveCatches = 0;//used to count consecutive Cathes

    private int _consecutiveMisses = 0;//used to slow down tokens if the player misses a lot in a row

    [SerializeField]
    private int _catchesToUpgrade = 0;//_consecutiveCatches needs to reach this number before rising the level


    private void Awake()//turns the gameobject into a singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameStart();
    }


    public void GameStart()
    {
        _snapshots[0].TransitionTo(.5f);
        //Token.fallSpeed = _initialSpeed;
    }


    public void Score()
    {
        _consecutiveCatches++;

        //float _newFallSpeed = Mathf.Lerp(Token.fallSpeed, _maxSpeed, _lerpT);

        //Token.fallSpeed = (_consecutiveMisses > 3) ? _currentSpeedSave : _newFallSpeed;

        _consecutiveMisses = 0;


        if (_consecutiveCatches >= _catchesToUpgrade)
        {
            _consecutiveCatches = 0;

            if (_index < (_snapshots.Length -1))
                _index++;

            _snapshots[_index].TransitionTo(.5f);
        }
    }

    public void Hurt()
    {
        _consecutiveCatches--;
        _consecutiveMisses++;

        if (_consecutiveCatches <= 0)
        {
            _consecutiveCatches = _catchesToUpgrade/2;

            if (_index > 0)
                _index--;

            _snapshots[_index].TransitionTo(.5f);
        }
    }
}
