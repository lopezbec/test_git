using UnityEngine;
using UnityEngine.UI;


public class CalculatorManager : MonoBehaviour
{
    
    private GameObject keyboard;
    public Text Expression; //points to the UI text field on the calculator Canvas
    private string ExpressionText; //actual text in the Text field component
    private string UpdatedExpressionText; //used as to store the updated equation text
    public float answer;


    public string newestNumber; //holds the number that is most recent until it hits a operator
    // Start is called before the first frame update
    void Start()
    {

        //Expression = this.transform.Find("Equation").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateString(string str)
    {

        ExpressionText = Expression.text;
        /*
        if(str == "^")
        {
            float temp = Evaluate(ExpressionText);
            
            UpdatedExpressionText = (temp * temp).ToString();
            ExpressionText = UpdatedExpressionText;
            if (ExpressionText.Length > 0)
                UpdatedExpressionText = ExpressionText.Substring(0, ExpressionText.Length - 1);
        }
        */
        if (str == "[backspace]") //remove the last number entered in the expression
        {
            if(ExpressionText.Length > 0)
            {
                string temp = ExpressionText.Substring(ExpressionText.Length - 1);
                if(temp.Length > 0 && (temp == "+" || temp == "-" || temp == "*" || temp == "/"))
                {
                    newestNumber = "";
                }
                print("newest calc number is: " + temp);
                UpdatedExpressionText = ExpressionText.Substring(0, ExpressionText.Length - 1);
                //if (newestNumber.Length > 0 && temp != "+" && temp != "-" && temp != "*" && temp != "/")
                //{
                //    newestNumber = newestNumber.Substring(0, ExpressionText.Length - 1);
                //}

                    
                    
                //UpdatedExpressionText = ExpressionText.Substring(0, ExpressionText.Length - 1); //deletes the last character by reassigning to the substring of itself -1
                
            }
            
        }
        else if (str == "[enter]") //evaluate the expression typed into the calculator
        {
            UpdatedExpressionText = Evaluate(ExpressionText).ToString();
            GameObject.Find("Graph").SendMessage("Addcalc", Evaluate(ExpressionText));
            newestNumber = "";
        }
        else if (str == "[clear]")
        {
            UpdatedExpressionText = "";
            newestNumber = "";
        }
        else //add a number or a operator to the expression
        {
            UpdatedExpressionText = ExpressionText + str;
            if(str != "+" && str != "-" && str != "*" && str != "/")
            {
                newestNumber += str;
            }
            else
            {
                newestNumber = "";
            }
        }

        Expression.text = UpdatedExpressionText;

    }

    //recursive function that evaluates the expression one number and operator at a time
    private float Evaluate(string expression) {

        //collect all the number characters into one string to convert to an actual number
        float num = 1;
        float newNum = 0;
        int i = 0;
        int j;

        //make sure string isnt empty
        if (expression.Length == 0)
            return -1234567890;

        //if first character is '-' the number is negative
        if (expression[i] == '-'){
            i++;
        }

        //make sure to multiply and divide before returning in order to preserve the order of operations
        //by doing this in a single function call and not recursively, we preserve the order of operations of basic mathematics
        while (expression[i] != '+' && expression[i] != '-'){
            //parse first numerical value
            while (expression[i] != '*' && expression[i] != '/' && expression[i] != '+' && expression[i] != '-'){
                i++;
                if (i == expression.Length)
                    break;
            }

            //parse the value out
            num = float.Parse(expression.Substring(0, i));
           

            //check to make sure this isnt the last value in the entire expression
            if (i == expression.Length)
                break;
            //if next operation is multiplication or division, get the other side and perform the operation before continuing
            if (expression[i] == '*' || expression[i] == '/'){
                j = i+1; //use j to iterate so that we keep track of where the second number started in the string with i

                //check again for a negative value
                if (expression[j] == '-'){
                    j++;
                }

                while (expression[j] != '*' && expression[j] != '/' && expression[j] != '+' && expression[j] != '-'){
                    j++;
                    if (j == expression.Length)
                        break;
                }

                //parse second value and apply negativity
                newNum = float.Parse(expression.Substring(i+1, j-i-1));
                
                //perform correct operation
                if (expression[i] == '*')
                    num = num * newNum;
                if (expression[i] == '/')
                    num = num / newNum;
                //if (expression[i] == '^')
                //num = num * num;
                print("num = " + num);
                print("i = " + i);
                print("j = " + j);
                print("newNum = " + newNum);
                i = j; //update the default iterator going forward
            }

            //check again to make sure this isnt the last value in the entire expression
            if (i == expression.Length)
                break;
        }


        //recursive conditions 
        if (i == expression.Length){
            return num;
        }
        else if (expression[i] == '+'){
            return (num + Evaluate(expression.Substring(i + 1))); //just recurse and perform the above process and add the result.
        }

        else if (expression[i] == '-'){
            return (num - Evaluate(expression.Substring(i + 1)));
        }


        else{ //something was wrong with the string expression
            return -123456789;
        }
     
      
    }



}
