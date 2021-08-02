using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundUI : MonoBehaviour
{
    public Text _textScoreCount;
    public Text _textScore;
    public Button _restartButton;
   
    public void Setup()
    {
        gameObject.SetActive(true);
        
        _textScore.text = _textScoreCount.text;
        
    }
    public void RestartScene()

    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
