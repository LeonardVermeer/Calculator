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
            for (int i = 0; i <= equation.Count - 2; i++) { //equation.Count - 2 because the last one will always be the = sign and the only digit which is the answer
                if (equation[i] == "/") { //PEDMAS
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 / num2);
                    equation.RemoveRange(i, 2);
                    i -= 1; //Adjust for the removed characters
                }
                else if (equation[i] == "x") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 * num2);
                    equation.RemoveRange(i, 2);
                    i -= 1;
                }

            }

            //All / and x calculations are done
            //Now only + and - are left

            for (int i = 0; i  < equation.Count - 2; i++) {
                if (equation[i] == "+") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 + num2);
                    equation.RemoveRange(i, 2);
                    i -= 1; //Adjust for the removed characters
                } 
            }

            //Now only the negative numbers remain and we can just add them together

            for (int i = 0; i <= equation.Count - 2; i++) {
                if (equation.Count >= 2) { //If there's anything left it's a negative and can be added
                    float.TryParse(equation[i], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i] = Convert.ToString(num1 + num2); //It doesn't matter which number has the negative it will be accounted for
                    equation.RemoveRange(i + 1, 1);
                    i -= 1;
                }
            }

            return equation[0].ToString();
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