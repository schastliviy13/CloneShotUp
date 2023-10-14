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
        //создаем новую часть уровня ровна над прошлой частью
        CreateLvl(curentLvl.transform.position+Vector3.up*20);
    }

    private void GameManager_OnChangeStateAction(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            //если произошел перезапуск отписываемся от текущей части уровня и удалем все части
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
        //создание новой части уровня
        //удаляем старую часть, назначаем новую старой
        //создаем новую часть и подписываемся на событие когда нужно создать следующую новую часть
        Destroy(oldLvl);
        oldLvl = curentLvl;
        curentLvl = Instantiate(prefabLvL, position, Quaternion.identity);
        curentLvl.GetComponent<Lvl>().newLvl.OnNewLvlAction += NewLvl_OnNewLvlAction;
    }
}
