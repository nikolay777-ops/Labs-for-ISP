using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Calc
{
    class RPN
    {
        static public double Calculate(string input)        // function for calculation and returning final result
        {
            string output = InfixToPostfix(input);
            double result = Counting(output);
            return result;
        }
        static private string InfixToPostfix(string input)          // function for converting string from infix to postfix math expression
        {
            string output = string.Empty;
            Stack<char> operandStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                {
                    continue;
                }
                if (Char.IsDigit(input[i]))
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    output += " ";
                    i--;
                }
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        operandStack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        char s = operandStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operandStack.Pop();
                        }
                    }
                    else
                    {
                        if (operandStack.Count > 0)
                        {
                            if (GetPriority(input[i]) <= GetPriority(operandStack.Peek()))
                            {
                                output += operandStack.Pop().ToString() + " ";
                            }
                        }
                        operandStack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }
            while (operandStack.Count > 0)
            {
                output += operandStack.Pop() + " ";
            }
            return output; 
        }
        static private double Counting(string input)        // function for counting 
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    string a = string.Empty;
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }   
                else   
                if (IsOperator(input[i]))
                {
                    double b = temp.Pop();
                    double c = temp.Pop();
                    switch (input[i])
                    {
                        case '+': result = c + b; break;
                        case '-': result = c - b; break;
                        case '*': result = c * b; break;
                        case '/': result = c / b; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(c.ToString()), double.Parse(b.ToString())).ToString()); break;
                    }
                        temp.Push(result);
                }
            }
            return temp.Peek();
        }
        static private bool IsDelimeter(char c)     // function for checking is the given character a delimeter or equal symbol
        {
            if ((" =".IndexOf(c) != -1))
            {
                return true;
            }
            return false;
        }
        static private bool IsOperator(char c)      // function for checking is the given character an operator
        {
            if (("+-*/^()".IndexOf(c) != -1))
            {
                return true;
            }
            return false;
        }
        static private byte GetPriority(char c)     // function for getting priority for operators
        {
            switch (c)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }
        static public bool CheckInput(string input)   // function for checking true-entering
        {
            if (input == "")
            {
                return false;
            }
            else
            {
                if (!Char.IsDigit(input[0]) && input[0] != '(' && input[0] != '-' && input[0] != '+')
                {
                    return false;
                }
                else
                {
                    if (!Char.IsDigit(input[input.Length - 1]) && input[input.Length - 1] != ')')
                    {
                        return false;
                    }
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        if (!IsOperator(input[i]) && !Char.IsDigit(input[i]) && (input[i] == '(' && input[i + 1] == ')') && (input[i] == ')' && input[i + 1] == '(') && !IsDelimeter(input[i]))
                        {
                            return false;
                        }
                        if (Char.IsDigit(input[i]) && input[i + 1] == '(')
                        {
                            Console.WriteLine("You didn't write any operation symbol");
                            return false;
                        }
                        if (input[i] == ')' && Char.IsDigit(input[i + 1]))
                        {
                            Console.WriteLine("You didn't write any operation symbol");
                            return false;
                        }
                        if (input[i] == '(' && IsOperator(input[i + 1]))
                        {
                            Console.WriteLine("You didn't write any number in operbrack.");
                            return false;
                        }
                        if (Char.IsDigit(input[i]) && input[i+1] == '.')
                        {
                            Console.WriteLine("You wrote dot (.) instead comma (,) please try again with correct symbol.");
                            return false;
                        }
                        if (IsOperator(input[0]))
                        {
                            Console.WriteLine("You probably wrote unary operation, but that calc can't calculate it at now.");
                            return false;
                        }
                    }
                    return true;
                }    
            }
        }
    };
    
    class Program: RPN
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter math expression: ");
                string mathexp = Console.ReadLine();
                bool checker = CheckInput(mathexp);
                if (checker == true)
                {
                    Console.WriteLine(RPN.Calculate(mathexp));
                }
                else
                {
                    Console.WriteLine("You entered a wrong math expression");
                }
            }
        }
    }
}
