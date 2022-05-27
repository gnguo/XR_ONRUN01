using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class src1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToReGameBtn()
    {
        SceneManager.LoadScene("2_LobbyScene");  //3_GameScene

    }
}
