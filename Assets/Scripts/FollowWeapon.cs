using UnityEngine;

public class FollowWeapon : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    private Transform _transform;
    public void Awake()
    {
        _transform = GetComponent<Transform>();
        GameManager.Instance.OnChangeStateAction += GameManager_OnChangeStateAction;
        
    }
    private void GameManager_OnChangeStateAction(object sender, System.EventArgs e)
    {
        //���� ������ ��������� ������ ���� �������� ������ � ������������ � ����
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            weapon = GameManager.Instance.GetCurentWeapon();
            _transform.position = new Vector3(_transform.position.x, weapon.transform.position.y, _transform.position.z);
        }
    }

    public void Update()
    {
        //���� ������� ��������� ���� ������� �� ��������� ���������� ������
        if (GameManager.Instance.gameState == GameManager.State.Game)
        {
            if (_transform.position.y < weapon.transform.position.y)
            {
                Vector3 newPosition = new Vector3(_transform.position.x, weapon.transform.position.y, _transform.position.z);
                _transform.position = Vector3.Lerp(_transform.position, newPosition, 3);
            }
        }        
    }
}
