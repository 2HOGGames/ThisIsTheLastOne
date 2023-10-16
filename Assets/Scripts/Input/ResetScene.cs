using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void ResetScenePressed()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
