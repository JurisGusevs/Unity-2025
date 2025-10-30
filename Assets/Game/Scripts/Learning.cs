using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Learning : MonoBehaviour
{
    private double decimalNumber = 0.435; // Floating point number 5.0 * 10 ^ 324 to -1.7 * 10 ^ 308
    public bool isPlayerDead = true; // false or true

    int num = 0; // Integer (whole number) -2,147,483,648 to 2,147,483,647 For example this is Int value
    int numPrivate = 0;
    char letter = 'i'; // Any char from the keyboard
    string str = "Juris Gusevs\" ^&^%^"; // String contains character sequense, basically array of charracters "/" marks a special character in the srting
    int[] muNumbers = { 1011, 12, 1354344, 14 };
    string[] myStrings = { "Test", "Test1", "Test3" };
    char[] myChar = { 'a', 'b' };

    [SerializeField] private int numPublic = 0;
    [SerializeField] private float floatNumber = 0; // Float value also stores floating point number but value from 	1.5 x 10 ^ 45 to -3.4 x 10 ^ 38

    string TestFunction()
    {
        string combind = "Value of integer: " + num;
        Debug.Log(myChar[1]);
        return combind;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string testStr = TestFunction();
        //if (decimalNumber == 0.435)
        //{
        //    Debug.Log("Length of the array is: " + myStrings.Length);
        //} else if(myChar.Length == 5)
        //{
        //    Debug.Log("Decimal didn't match this is else block");
        //} else
        //{

        //}

        //switch(num)
        //{
        //    case 0:
        //        Debug.Log("Num is 0");
        //        break;
        //    case 1:
        //        Debug.Log("Num is 0");
        //        break;
        //}

        //for (int i = 0; i != -1; i++) {
        //    Debug.Log("I value is: " + i);
        //}

        //foreach (string oneString in myStrings)
        //{
        //    Debug.Log(oneString);
        //}

        //while (num <= 5)
        //{
        //    Debug.Log("Num value is: " + num);
        //    num++;
        //}

        do
        {
            Debug.Log("Num value is: " + num);
            num++;
        } while (num < -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// Useful to know but not really obligatory
class Car
{
    private string color;
    public string numberPlate;
    public int horsePower;

    public Car()
    {
        color = "red";
        numberPlate = "HG4234";
        horsePower = 100;
    }

    public Car(string some)
    {
        color = some;
        numberPlate = "HG4234";
        horsePower = 100;
    }

    public Car(string color, string numberPlate, int horsePower)
    {
        this.color = color;
        this.numberPlate = numberPlate;
        this.horsePower = horsePower;
    }

    public void PrintCarColor()
    {
        Debug.Log("This car is: " + color);
    }
}

class BMW : Car
{
    string name;

    public BMW(int power, string plate) {
        this.name = plate;
    }

}
