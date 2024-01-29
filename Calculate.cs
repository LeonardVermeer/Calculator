using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator {
    internal class Calculate {
        List <String> numbers = new List <String> (); //Can't this just be a string?
        List <String> equation = new List <String> ();

        public void InsertNumber(char Num) {
            numbers.Add(Convert.ToString(Num));
        }

        private void InsertNumberIntoEquation() {
            string number = "";

            foreach (string num in numbers) {
                number += num;
            }
    
            equation.Add(number);
            numbers = new List<string>();
        }

        public void InsertOperator(string Operator) {
            if (Operator == "-") {
                InsertNumberIntoEquation();
                numbers = new List<string> ();
                numbers.Insert(0, "-");//can't insert a negative into the number
                return;  
            }

            InsertNumberIntoEquation();
            equation.Add(Operator);
        }

        public string Calculation() {
            //I have to use loops and call functions
            //"In C#, when a function calls another function,
            //and that second function calls the original function,
            //it creates a new instance of the stack frame for each function call.
            //Each stack frame maintains its own set of local variables, including parameters,
            //and has its own execution context."            

            for (int i = 0; i <= equation.Count - 1; i++) { //equation.Count - 1 because the last one will always be a number or can be ignored
                if (equation[i] == "/") { //PEDMAS
                    float.TryParse(equation[i - 1], out float num1);
                    
                    //Instead of manually trying to work with negatives
                    //add the negative to the number and continue as normal
                    //The list would then look like
                    //3 -4 + 2 -5 / -2 + 3 / -6
                    //0  1 2 3 4  5  6 7 8 9 10

                    float.TryParse(equation[i + 1], out float num2);
                    

                    equation[i - 1] = Convert.ToString(num1 / num2);
                    equation.RemoveRange(i, 2);
                    i -= 2; //Adjust for the removed characters
                }
                else if (equation[i] == "x") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 * num2);
                    equation.RemoveRange(i, 2);
                    i -= 2;
                }

            }

            ////All / and x calculations are done
            ////Now only + and - are left

            //while (equation.Count > 2) {
            //    if (equation[1] == "+") {
            //        float.TryParse(equation[0], out float num1);
            //        float.TryParse(equation[2], out float num2);

            //        equation[0] = Convert.ToString(num1 + num2);
            //        equation.RemoveRange(1, 2);
            //    }
            //    else if (equation[1] == "-") {
            //        float.TryParse(equation[0], out float num1);
            //        float.TryParse(equation[2], out float num2);

            //        equation[0] = Convert.ToString(num1 - num2);
            //        equation.RemoveRange(1, 2);
            //    }
            //}

            for (int i = 0; i  < equation.Count - 1; i++) {
                if (equation[i] == "+") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 + num2);
                    equation.RemoveRange(i, 2);
                    i -= 2; //Adjust for the removed characters
                } else if (equation.Count == 3) {
                    float.TryParse(equation[0], out float num1);
                    float.TryParse(equation[1], out float num2);

                    equation[0] = Convert.ToString(num1 + num2);//It doesn't matter which number has the negative it will be accounted for
                    return equation[0].ToString();
                }
            }

            return equation[0].ToString();


            //return "";
        }

        //public bool IsLastCharacterASymbol() {
        //    //check if the list number has some value, if it has then it should be added to equation
        //    //else the last element in equation is a symbol
        //    if (numbers.Count > 0) {
        //        InsertNumberIntoEquation(); //BUG: negative numbers won't reflect / be sent to the next number
        //        return false;
        //    } else { return true; }
        //    //Or calculate them regardless (- x - = +)
        //    //If - x - = + then - / - = +

        //    //if numbers.count > 0 there's a number not yet added to the equation and should be added
        //    //if (equation.Count > 0) {
        //    //    if (equation[equation.Count - 1] == "x" || equation[equation.Count - 1] == "/" || equation[equation.Count - 1] == "," /*|| equation[equation.Count - 1] == "="*/) {
        //    //        return true;
        //    //    }
        //    //}            

        //    //return false;
        //}

        public void Clear() {
            numbers = new List<String>();
            equation = new List<String>();
        }
    }
}