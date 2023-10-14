using UnityEngine;

public class LvLManager : MonoBehaviour
{
    public static LvLManager Instance { get; private set; }

    [SerializeField] private GameObject prefabLvL;
    [SerializeField] private GameObject curentLvl;
    [SerializeField] private GameObject oldLvl;

    void Awake()
    {
        Instance = this;
        GameManager.Instance.OnChangeStateAction += GameManager_OnChangeStateAction;
    }
    private void NewLvl_OnNewLvlAction(object sender, System.EventArgs e)
    {
        //������� ����� ����� ������ ����� ��� ������� ������
        CreateLvl(curentLvl.transform.position+Vector3.up*20);
    }

    private void GameManager_OnChangeStateAction(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            //���� ��������� ���������� ������������ �� ������� ����� ������ � ������ ��� �����
            if (curentLvl!=null)
            {
                curentLvl.GetComponent<Lvl>().newLvl.OnNewLvlAction -= NewLvl_OnNewLvlAction;
            }            
            Destroy(oldLvl);
            Destroy(curentLvl);
            CreateLvl(new Vector3(0, 9.35f, 1));
        }

    }
    private void CreateLvl(Vector3 position)
    {
        //�������� ����� ����� ������
        //������� ������ �����, ��������� ����� ������
        //������� ����� ����� � ������������� �� ������� ����� ����� ������� ��������� ����� �����
        Destroy(oldLvl);
        oldLvl = curentLvl;
        curentLvl = Instantiate(prefabLvL, position, Quaternion.identity);
        curentLvl.GetComponent<Lvl>().newLvl.OnNewLvlAction += NewLvl_OnNewLvlAction;
    }
}
