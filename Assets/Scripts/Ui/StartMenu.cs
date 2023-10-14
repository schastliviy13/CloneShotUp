using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelWeaponSelection;
    public void Start()
    {
        GameManager.Instance.ChangeState(GameManager.State.StartMenu);
    }
    public void StartGame()
    {
        //загружаем сцену игры, если она загрузилась выставляем новое игровое состояние
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0== SceneManager.GetSceneByBuildIndex(1))
        {
            GameManager.Instance.ChangeState(GameManager.State.StartGame);
        }        
    }

    public void OpenPanelWeaponSelection()
    {
        panelWeaponSelection.SetActive(true);
    }
    public void ClosePanelWeaponSelection()
    {
        panelWeaponSelection.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
