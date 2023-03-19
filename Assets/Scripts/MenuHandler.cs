using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScore;
    public void Awake()
    {
        highScore.text = $"Best Score: {GameManager.Instance.namesSaved[0]} - {GameManager.Instance.scoresSaved[0]}";
    }
    public void StartGame()
    {
        
        GameObject nameInput = GameObject.Find("Name");
        if(nameInput.GetComponent<TMP_InputField>().text != "")
        {
            GameManager.Instance.name = nameInput.GetComponent<TMP_InputField>().text;
        }
        else
        {
            GameManager.Instance.name = "Anonymous";
        }
        
        SceneManager.LoadScene(1);
    }
    public void ScoreRanking()
    {
        SceneManager.LoadScene(2);
    }
   
    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
         Application.Quit();
#endif
    }
    
}
