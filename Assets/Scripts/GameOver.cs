using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon Weapon))
        {
            GameManager.Instance.ChangeState(GameManager.State.GameOver);
            Debug.Log("Game Over");
        }
    }
}
