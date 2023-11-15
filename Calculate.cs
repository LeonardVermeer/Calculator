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

        private void InsertNumberIntoEquation() {
            string number = "";
            foreach (string num in numbers) {
                number += num;
            }
            equation.Add(number);
        }

        public void InsertOperator(string Operator) {
            InsertNumberIntoEquation();
            equation.Add(Operator);

            numbers = new List<string> ();
        }

        public string Calculation() {
            InsertNumberIntoEquation();

            //loop through uneaven indexes and if a / or a x is found, calculate
            //then loop through uneaven indexes and calculate

            //Start at an operator index 0 will always be a number
            for (int i = 1; i <= equation.Count - 1; i+= 2) { //equation.Count - 1 because the last one will always be a number
            //All symbols will be in uneaven indexes
                if (equation[i] == "/") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 / num2);
                    equation.RemoveRange(i, 2);
                    i -= 2;
                } else if (equation[i] == "x") {
                    float.TryParse(equation[i - 1], out float num1);
                    float.TryParse(equation[i + 1], out float num2);

                    equation[i - 1] = Convert.ToString(num1 * num2);
                    equation.RemoveRange(i, 2);
                    i -= 2;
                }
                
            }

            //All / and x calculations are done
            //Now only + and - are left

            while (equation.Count > 2) { 
                if (equation[1] == "+") {
                    float.TryParse(equation[0], out float num1);
                    float.TryParse(equation[2], out float num2);

                    equation[0] = Convert.ToString(num1 + num2);
                    equation.RemoveRange(1, 2);
                } else if (equation[1] == "-") {
                    float.TryParse(equation[0], out float num1);
                    float.TryParse(equation[2], out float num2);

                    equation[0] = Convert.ToString(num1 - num2);
                    equation.RemoveRange(1, 2);
                }
            }
            return equation[0].ToString();
        }

        public void Clear() {
            numbers = new List<String>();
            equation = new List<String>();
        }
    }
}