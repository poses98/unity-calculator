using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{

    [SerializeField]
    private GameObject display;

    [SerializeField]
    private GameObject memIndicator;

    [SerializeField]
    private GameObject operationIndicator;

    private TextMeshProUGUI displayMesh;

    private TextMeshProUGUI operationMesh;

    private string displayText;

    private string operation;

    private string badOperation;

    private double result;

    private double memory;

    // Start is called before the first frame update
    void Start()
    {
        displayMesh = display.GetComponent<TextMeshProUGUI>();
        operationMesh = operationIndicator.GetComponent<TextMeshProUGUI>();
        displayText = "0";
    }

    // Update is called once per frame
    void Update()
    {

        memIndicator.SetActive(memory != 0);
        displayMesh.text = displayText ;
        operationMesh.text = operation;
    }

    public void AddNumber(string number)
    {
        if(displayText == "0" && number != ".")
        {
            displayText = "";
        }

        if(result != 0)
        {
            result = 0;
            displayText = "";
            operation = "";
        }

        if(displayText.Length < 10)
        {
            displayText += number;
            operation += number;
        }
    }

    public void AddOperator(string op)
    {
        displayText = "0";
        operation += op;
    }

    public void ComputeEquals()
    {
        result = Evaluar(operation);
        displayText = result.ToString();
    }

    public void ClearScreen()
    {
        operation = "";
        displayText = "0";
    }

    public void MemPlus()
    {
        memory += Double.Parse(displayText);
        print(memory);
    }

    public void MemShow()
    {
        displayText = memory.ToString();
    }


    public void MemMinus()
    {
        memory -= Double.Parse(displayText) ;
        print(memory);
    }

    public void MemClear()
    {
        memory = 0;
        print(memory);
    }

    public void Del()
    {

        if(result != 0 || operation.ToCharArray()[operation.Length-1] == '/' || operation.ToCharArray()[operation.Length - 1] == '*' || operation.ToCharArray()[operation.Length - 1] == '+' || operation.ToCharArray()[operation.Length - 1] == '-')
        {
            ClearScreen();
        }
        else
        {

            displayText = displayText.Remove(displayText.Length - 1);

        }

    }

    static double Evaluar(string expression)
    {
        //Creo un DataTable
        System.Data.DataTable table = new System.Data.DataTable();
        //Realizo el cálculo..
        object result = table.Compute(expression, string.Empty);
        //Lo devuelvo convertido a Double
        return Math.Round(Convert.ToDouble(result),5);
    }
}
