using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator {
    internal class Calculate {
        List <String> numbers = new List <String> ();
        List <String> equation = new List <String> ();

        public void InsertNumber(char Num) {
            numbers.Add(Convert.ToString(Num));
        }

        private void InsertNumberIntoEquation(bool isNegative = false) {
            string number = "";

            foreach (string num in numbers) {
                number += num;
            }

            if (isNegative) {
               number.Insert(0, "-");
            }
    
            equation.Add(number);
        }

        public void InsertOperator(string Operator) {
            if (Operator == "-") {
                InsertNumberIntoEquation(true);
            } else {
                InsertNumberIntoEquation();
            }

            equation.Add(Operator);

            numbers = new List<string> ();
        }

        public string Calculation() {
            InsertNumberIntoEquation(); //Add in the last number
            //I have to use loops and call functions
            //"In C#, when a function calls another function,
            //and that second function calls the original function,
            //it creates a new instance of the stack frame for each function call.
            //Each stack frame maintains its own set of local variables, including parameters,
            //and has its own execution context."            

            for (int i = 0; i <= equation.Count - 1; i++) { //equation.Count - 1 because the last one will always be a number or can be ignored
                if (equation[i] == "/") {
                    float.TryParse(equation[i - 1], out float num1);
                    if (equation[i - 2] == "-") { num1 *= -1; }
                    //Instead of manually trying to work with negatives
                    //add the negative to the number and continue as normal
                    //The list would then look like
                    //3 -4 + 2 -5 / -2 + 3 / -6
                    //0  1 2 3 4  5  6 7 8 9 10

                    //float.TryParse(equation[i + 1], out float num2);
                    if (equation[i + 1] == "-") { 
                        float.TryParse(equation[i + 2], out float num2);
                    }

                    equation[i - 1] = Convert.ToString(num1 / num1); //num1 / num2 check (just to remove error)
                    equation.RemoveRange(i, 2);
                    i -= 2;
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
            //    } else if (equation[1] == "-") {
            //        float.TryParse(equation[0], out float num1);
            //        float.TryParse(equation[2], out float num2);

            //        equation[0] = Convert.ToString(num1 - num2);
            //        equation.RemoveRange(1, 2);
            //    }
            //}
            //return equation[0].ToString();

            return "";
        }

        public string Divide(string num1, string num2) {
            float.TryParse(num1, out float num1f);
            float.TryParse(num2, out float num2f);

            return Convert.ToString(num1f / num2f);
        }
        
        public string Multiply(string num1, string num2) {
            float.TryParse(num1, out float num1f);
            float.TryParse(num2, out float num2f);

            return Convert.ToString(num1f * num2f);
        }
        
        public string Add(string num1, string num2) {
            float.TryParse(num1, out float num1f);
            float.TryParse(num2, out float num2f);

            return Convert.ToString(num1f + num2f);
        }
        
        public string Subtract(string num1, string num2) {
            float.TryParse(num1, out float num1f);
            float.TryParse(num2, out float num2f);

            return Convert.ToString(num1f - num2f);
        }

        public bool IsSymbolTheLastCharacter(string symbol) {
            //Check if some symbol isn't before another
            //Or calculate them regardless (- x - = +)
            //If - x - = + then - / - = +
            if (numbers.Count > 0) {
                if (numbers[numbers.Count - 1] == symbol) {
                    return true; //The symbol is already in the equation
                }
            }

            if (equation.Count > 0) {
                if (equation[equation.Count - 1] == symbol) {
                    return true;
                }
            }            

            return false;
        }

        public void Clear() {
            numbers = new List<String>();
            equation = new List<String>();
        }
    }
}