using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //�������� �� ������ ������, ���������� ��������� � ����� ���������� ��� ���� ��������� �������� �� �������������
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
    //�������� ������ ����� ������������� � ������� ���������� �� �����. ��� ������
    //��������� ���������� �� ��� ��������
    public void SetWeaponDesertEagle()
    {
        SetWeapon(0);
    }
}
