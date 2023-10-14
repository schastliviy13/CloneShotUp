using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelGame;
    [SerializeField] private GameObject panelGameOver;
    public void Start()
    {
        GameManager.Instance.OnChangeStateAction += GameManager_OnChangeStateAction;
    }

    private void GameManager_OnChangeStateAction(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.gameState==GameManager.State.GameOver)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void PauseOn()
    {
        panelPause.SetActive(true);
        panelGame.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.State.Pause);
    }
    public void PauseOff()
    {
        panelPause.SetActive(false);
        panelGame.SetActive(true);
        GameManager.Instance.ChangeState(GameManager.State.Game);
    }
    public void RestartScene()
    {
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGame.SetActive(true);
        GameManager.Instance.ChangeState(GameManager.State.Restar);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
