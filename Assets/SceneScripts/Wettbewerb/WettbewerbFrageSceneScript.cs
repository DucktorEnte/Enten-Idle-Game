using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WettbewerbFrageSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("WettbewerbFrageAntwortScene", LoadSceneMode.Additive);
    }

}
