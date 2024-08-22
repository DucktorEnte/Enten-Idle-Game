using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "schwierigste Mathefrage ever", menuName = "neue Wettbewerbsfrage")]
public class Wettbewerbsfrage : ScriptableObject
{
    public string frage;

    public string antwort_1;
    public string antwort_2;
    public string antwort_3;
    public string antwort_4;

    public int richtigeAntowrt=1;
}
