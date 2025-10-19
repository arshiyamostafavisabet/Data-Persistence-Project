using UnityEngine;
using UnityEditorInternal;
using TMPro;
using System.Security.Policy;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering;





#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.SceneManagement;


[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public TMP_InputField inputField;
    public string playerName;
    public int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SaveManager.instance.LoadData();
        playerName = SaveManager.instance.playerName;
        highScore = SaveManager.instance.highScore;
        string textFieldText = "Best Score:" + playerName + ":" + highScore;
        textField.text = textFieldText;
    }
    public void StartNew()
    {
        SaveManager.instance.playerName = inputField.text;
        SaveManager.instance.Save();
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Exit()
    {
        SaveManager.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

}