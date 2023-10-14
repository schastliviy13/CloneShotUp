using System;
using UnityEngine;


public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject bulletSpawnPoint;//������� �������� ����
    [SerializeField] private GameObject Point;//������� ����� ���������, ���������� ��� ����������� ���������� ��������

    private Vector3 direction;

    protected Rigidbody _rigidbody;
    protected Transform _transform;
    protected float forceShot=13.5f;
    protected float forceRotate = 50;

    public int countBullet=10;

    public event EventHandler OnChangeCountBulletAction;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

    }
    public void Shoot()
    {
        //�������� �������� �� ����������� ����������
        if (countBullet == 0) return;
        countBullet -= 1;
        OnChangeCountBulletAction?.Invoke(this, EventArgs.Empty);

        //���������� ��������� ������� ������
        if (bulletSpawnPoint!=null && Point!=null)
        {
            direction = bulletSpawnPoint.transform.position - Point.transform.position;
        }        

        AddForce(-direction,forceShot);

        //����������� ������� ��������� �� ����������� ������
        _rigidbody.AddTorque(new Vector3(0,0,direction.normalized.x) * forceRotate, ForceMode.Impulse);

        //�������� ����
        Instantiate(prefabBullet, bulletSpawnPoint.transform.position, Quaternion.Euler(direction));
    }
    //����� ������ ���������� ���� ������ � ��������� �����, ��� ��������� ������ �� ������
    public void AddForce(Vector3 direction, float forceShot)
    {
        //���������� ������� �� ������ � �������
        direction = direction.normalized;
        direction = new Vector3(direction.x / 2, direction.y, direction.z / 2);

        //��������� ���� ������
        _rigidbody.AddForce(direction * forceShot, ForceMode.Impulse);
    }
    public void AddBullet(int countBullet)
    {
        this.countBullet += countBullet;
        OnChangeCountBulletAction?.Invoke(this, EventArgs.Empty);
    }
}
