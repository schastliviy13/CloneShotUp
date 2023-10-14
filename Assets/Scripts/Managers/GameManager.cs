using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Vector3 StartPointWeapon = new Vector3(0, 11.5f, 0);
    private GameObject curentWeapon;

    public event EventHandler OnChangeStateAction;   

    public enum State
    {
        StartMenu,
        StartGame,
        Game,
        Pause,
        Restar,
        GameOver
    }
    public State gameState;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        OnChangeStateAction += GameManager_OnChangeStateAction;
        DontDestroyOnLoad(gameObject);
    }

    private void GameManager_OnChangeStateAction(object sender, EventArgs e)
    {
        switch (gameState)
        {
            case State.StartMenu:
                Exit();
                break;
            case State.StartGame:
                StartGame();
                break;
            case State.Game:
                Game();
                break;
            case State.Pause:
                Pause();
                break;
            case State.Restar:
                Restart();
                break;
            case State.GameOver:
                break;
        }
    }

    public void ChangeState(State state)
    {
        if (gameState == state) return;
        gameState = state;
        OnChangeStateAction?.Invoke(this, EventArgs.Empty);
    }
    public GameObject GetCurentWeapon()
    {
        return curentWeapon;
    }
    public void StartGame()
    {
        Debug.Log("Старт игры");
        curentWeapon = Instantiate(WeaponManager.Instance.GetWeapon(), StartPointWeapon, Quaternion.Euler(0, 0, -80));
        Time.timeScale = 0f;
    }
    public void Game()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Destroy(curentWeapon);
        ChangeState(State.StartGame);
    }
    public void Exit()
    {
        Destroy(curentWeapon);
    }
}
