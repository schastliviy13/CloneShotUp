using System;
using UnityEngine;
using UnityEngine.UI;

public class CountBulletUI : MonoBehaviour
{
    [SerializeField] Text countBulletText;
    [SerializeField] private Weapon weapon;
    public void Awake()
    {
        GameManager.Instance.OnChangeStateAction += GameManager_OnChangeStateAction;
    }

    private void GameManager_OnChangeStateAction(object sender, EventArgs e)
    {
        //если игровое состояние игра получаем оружие и подписываемся на его метот изменения сол-ва пуль
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            weapon = GameManager.Instance.GetCurentWeapon().GetComponent<Weapon>();
            weapon.OnChangeCountBulletAction += Weapon_OnChangeCountBulletAction;
        }
    }

    private void Weapon_OnChangeCountBulletAction(object sender, EventArgs e)
    {
        countBulletText.text = weapon.GetBullet().ToString();
    }
}
