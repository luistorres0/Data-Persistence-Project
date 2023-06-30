using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUI : MonoBehaviour
{
    public InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        nameInput.onEndEdit.AddListener(GameData.Instance.savePlayerName);
    }

    private void LoadMain()
    {
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
