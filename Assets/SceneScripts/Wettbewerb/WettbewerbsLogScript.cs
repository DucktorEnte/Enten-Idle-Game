using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WettbewerbsLogScript : MonoBehaviour
{

    public GameManager gameManager;

    public TMP_Text frage;

    public Button button_1;
    public TMP_Text button_1_text;

    public Button button_2;
    public TMP_Text button_2_text;

    public Button button_3;
    public TMP_Text button_3_text;

    public Button button_4;
    public TMP_Text button_4_text;


    public int richtigeAntwort;

    public  Wettbewerbsfrage[] alleFragen;
    public Wettbewerbsfrage ausgFrage;

    // Start is called before the first frame update
    void Start()
    {
        alleFragen=Resources.LoadAll<Wettbewerbsfrage>("ScriptableObjectsEntities/Wettbewerbsfragen");
        button_1.onClick.AddListener(() => { MyButtonClick(button_1); });
        button_2.onClick.AddListener(() => { MyButtonClick(button_2); });
        button_3.onClick.AddListener(() => { MyButtonClick(button_3); });
        button_4.onClick.AddListener(() => { MyButtonClick(button_4); });
        loadzufaelligeFrage();
    }


    void MyButtonClick(Button sender)
    {
        int given_Anwser = 0;
        if (sender.name == "Button 1") {
            given_Anwser = 1;
        }
        if (sender.name == "Button 2")
        {
            given_Anwser = 2;
        }
        if (sender.name == "Button 3")
        {
            given_Anwser = 3;
        }
        if (sender.name == "Button 4")
        {
            given_Anwser = 4;
        }
        Logger.Normal(sender.name);

        if (richtigeAntwort == given_Anwser) {
            gameManager.addGold();
        
        }
        SceneManager.LoadScene("Tigerentenschule");
        gameManager.lastSceneName = "Tigerentenschule";
    }

    private void loadzufaelligeFrage()
    {
        //Bei nicht zufälligen Fragen, dies aukommentieren und die frage direkt in unity reinziehen.
        ausgFrage= alleFragen[Random.Range(0, alleFragen.Length)];
        


        richtigeAntwort = ausgFrage.richtigeAntowrt;
        frage.SetText(ausgFrage.frage);
        button_1_text.SetText(ausgFrage.antwort_1);
        button_2_text.SetText(ausgFrage.antwort_2);
        button_3_text.SetText(ausgFrage.antwort_3);
        button_4_text.SetText(ausgFrage.antwort_4);
        
    }

}
