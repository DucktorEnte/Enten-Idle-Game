using UnityEngine;

public class Logger : MonoBehaviour
{
    private static Logger _instance;
    private static bool cricticalMsg = true;
    private static bool normalMsg = true;

    //set this to true, to remove all logs except for the devtestlogs;
    private static bool developmentTestLog = true;

    public static Logger Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public static void Critical(string msg) {
        if (cricticalMsg && !developmentTestLog) Debug.Log("critical Error: " + msg);
 
    }

    public static void Normal(string msg) {
        if (normalMsg && !developmentTestLog) Debug.Log( msg);
    }

    public static void DevTest(string msg) {
        if (developmentTestLog) Debug.Log(msg);
    }

}