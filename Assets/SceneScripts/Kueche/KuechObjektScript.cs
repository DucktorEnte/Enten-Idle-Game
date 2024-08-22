using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KuechObjektScript : MonoBehaviour
{

    public Gericht gericht;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer.sprite = gericht.food.sprite;
    }
    public int OnClick() {
        return gericht.nummer;
    }

}
