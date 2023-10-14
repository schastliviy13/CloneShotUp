using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //менеджер по выбору оружия, запоминает выбранное и будет передавать его всем остальным скриптам по необходимости
    public static WeaponManager Instance { get; private set; }

    private GameObject selectedWeapon;
    [SerializeField] List<Weapon> pullWeapons = new List<Weapon>();

    public void Awake()
    {
        Instance = this;
    }
    private void SetWeapon(int index)
    {
        selectedWeapon = pullWeapons[index].gameObject;
    }
    public GameObject GetWeapon()
    {
        return selectedWeapon;
    }
    //подобные методы будут подвязываться к кнопкам отвещающим за опред. вид оружия
    //выполнено примитивно тк это прототип
    public void SetWeaponDesertEagle()
    {
        SetWeapon(0);
    }
}
