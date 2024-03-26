using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{

    [SerializeField]
    private GameObject display;
    private TextMeshProUGUI textMesh;

    private string displayText;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = display.GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = displayText;
    }

    public void AddNumber(int number)
    {
        print(number);
        displayText += number;
    }

    public void AddOperator(string op)
    {
        print(op);
    }
}
