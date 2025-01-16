using System.Collections;
using System.Collections.Generic;
using System.Net;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private int _remainingLives = 3;
    
    public GameObject panelMenu;
    public GameObject panelPause;
    public GameObject panelGameOver;
    public GameObject panelPlay;
    
    private float _score;
    private GameObject _player;
    private StateEnum _currentState;
    private int _currentLife;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentLife = _remainingLives;
        SwitchState(StateEnum.MENU);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_currentState);
    }
    
    public void SwitchState(StateEnum newState)
    {
        EndState();
        BeginState(newState);
    }

    private void BeginState(StateEnum state)
    {
        switch (state)
        {
            case StateEnum.MENU:
                panelMenu.SetActive(true);
                _currentState = state;
                break;
            case StateEnum.START:
                if (!_player) _player = Instantiate(_playerPrefab);
                state = StateEnum.PLAY;
                BeginState(state);
                break;
            case StateEnum.PLAY:
                if (Time.timeScale == 0) Time.timeScale = 1;
                panelPlay.SetActive(true);
                _currentState = state;
                break;
            case StateEnum.PAUSE:
                panelPause.SetActive(true);
                Time.timeScale = 0;
                _currentState = state;
                break;
            case StateEnum.GAMEOVER:
                panelGameOver.SetActive(true);
                Time.timeScale = 0;
                _currentState = state;
                break;
        }

    }

    private void EndState()
    {
        switch (_currentState)
        {
            case StateEnum.MENU:
                panelMenu.SetActive(false);
                break;
            case StateEnum.PLAY:
                panelPlay.SetActive(false);
                break;
            case StateEnum.PAUSE:
                panelPause.SetActive(false);
                break;
            case StateEnum.GAMEOVER:
                panelGameOver.SetActive(false);
                _score = 0;
                Time.timeScale = 1;
                break;
        }
    }
    
    public void OnPlayPressed() => SwitchState(StateEnum.START);
    
    public void OnPausePressed() => SwitchState(StateEnum.PAUSE);
    
    public void OnResumePressed() => SwitchState(StateEnum.PLAY);
}
