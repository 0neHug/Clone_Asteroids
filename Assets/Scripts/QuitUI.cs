
using UnityEngine;
using UnityEngine.UI;

public class QuitUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Button quitButton;

    public void QuitTap()
    {
        Application.Quit();
    }
}
