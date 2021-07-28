using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenuController : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private InputField _inputField;

    private void Start()
    {
        _inputField.onValueChanged.AddListener(OnNicknameChanged);
        
        score.text = $"Score: {DataTransferManager.Instance.Nickname}: {DataTransferManager.Instance.Score}";
    }

    public void OnNicknameChanged(string newNickname)
    {
        DataTransferManager.Instance.Nickname = newNickname;
    }
    
    public void LaunchGame()
    {
        SceneManager.LoadScene("main");
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        DataTransferManager.Instance.Save();
    }
}
