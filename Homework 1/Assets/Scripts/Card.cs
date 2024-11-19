using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public int Number;
    public int NumberAdd;
    public Color ColorC;
    public string Uno;
    public string NoU;


    public Image ColorDisplayed;
    public TextMeshProUGUI NumberDisplayed;
    public TextMeshProUGUI TitleDisplayed;
    // Start is called before the first frame update
    void Start()
    {
        ColorC = Color.red;
      
    }

    // Update is called once per frame
    void Update()
    {


    }
   
  public void NumberChange (int NumberAdd)
    {
        Number = Number + NumberAdd;
        NumberDisplayed.text = Number.ToString();
    }

  public void     TextToUno() {

        TitleDisplayed.text = Uno;
    }
   public void TextToNoU() { TitleDisplayed.text = NoU; }
   public void ColorChange() {
        if (ColorC == Color.red)
        {
            ColorC = Color.blue;
            ColorDisplayed.color = ColorC;
        }
        else if (ColorC == Color.blue)
        {
            ColorC = Color.yellow;
            ColorDisplayed.color = ColorC;
        }
        else if (ColorC == Color.yellow)
        {
            ColorC = Color.green;
            ColorDisplayed.color = ColorC;
        }
        else if (ColorC == Color.green)
        {
            ColorC = Color.red;
            ColorDisplayed.color = ColorC;
        }

    }
}
