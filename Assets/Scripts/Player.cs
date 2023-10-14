using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] private Weapon weapon;    

    private void Awake()
    {        
        GameManager.Instance.OnChangeStateAction += GameManager_OnChangeStateAction;
    }
    public void Start()
    {
        GameInput.Instance.OnPressAction += GameInput_OnPressAction;
    }

    private void GameManager_OnChangeStateAction(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            weapon = GameManager.Instance.GetCurentWeapon().GetComponent<Weapon>();
        }
    }

    private void GameInput_OnPressAction(object sender, System.EventArgs e)
    {
        //при первом нажатии при запуске или перезапуске игры оставляю возможность подготовиться
        //пока не произошло первое нажатие игра не запуститься
        if (GameManager.Instance.gameState == GameManager.State.StartGame)
        {
            GameManager.Instance.ChangeState(GameManager.State.Game);
        }

        if (GameManager.Instance.gameState== GameManager.State.Game)
        {            
            weapon.Shoot();
        }        
    }
    
}
