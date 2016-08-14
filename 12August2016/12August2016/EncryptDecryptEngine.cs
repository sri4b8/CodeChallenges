using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12August2016
{
    public class EncryptDecryptEngine
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            EncryptDecryptEngine program = new EncryptDecryptEngine();

            string encryptedMessage = program.EncryptMessage(input); // getting encrypted message with numsp

            string decryptedMessage = program.DecryptMessage(encryptedMessage); //passsing encrypted message to get decrypted message with added spaces 

            Console.WriteLine("Encrypted Message :" + encryptedMessage); // show encrypted message

            Console.WriteLine("Decrypted Message :" + decryptedMessage); // show Decrypted  message

            Console.ReadLine();

        }

        // get encrypted message 
        public string EncryptMessage(string input)
        {
            string message = string.Empty;
            List<int> numSps = new List<int>();
            int numSp = 1;
            try
            {
                //getting white spaces indexs (numsp) and remove space from the message
                foreach (char c in input)
                {
                    if (c == ' ')
                    {
                        numSps.Add(numSp);

                    }
                    else
                    {
                        numSp++;
                        message = message + c.ToString();
                    }
                }

                int l = message.Length;//length of the message excluding spaces

                int squareRoot = (int)Math.Sqrt(l);
                int columns = squareRoot;
                int rows = squareRoot;

                columns = (rows * columns >= l) ? columns : columns + 1;

                rows = (rows * columns >= l) ? rows : rows + 1;

                string[] encryptedMessage = new string[rows];
                int index = 0;

                // spliting message into rows
                for (int i = 0; i < rows - 1; i++)
                {
                    encryptedMessage[i] = message.Substring(index, columns);
                    index += columns;
                }

                encryptedMessage[rows - 1] = message.Substring(index); //we are adding last row at end because last row might have different column size

                string[] finalMessage = new string[columns];


                for (int k = 0; k < columns; k++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (encryptedMessage[i].Length > k)
                        {
                            finalMessage[k] += encryptedMessage[i][k]; // adding same columns in a different rows 
                        }
                    }
                }


                return string.Join(" ", finalMessage) + " numsp " + String.Join(" ", numSps); // adding spaces in beetween encrypted codes and added white space positions

            }
            catch (Exception ex)
            {
                return "Error :" + ex.Message;
            }
        }

        // get decrypted message         
        public string DecryptMessage(string input)
        {
            try
            {
                string[] inputs = Regex.Split(input, " numsp ");// spliting input to get encrypted message and white space indexs
                string message = inputs[0];
                string numsp = inputs[1];

                string[] encryptedMessage = message.Split(' ');//splting encrypted array
                int rows = encryptedMessage[0].Length;
                int columns = encryptedMessage.Length;

                string[] decryptedMessageArray = new string[rows];


                for (int k = 0; k < rows; k++)
                {
                    for (int i = 0; i < columns; i++)
                    {
                        if (encryptedMessage[i].Length > k)
                        {
                            decryptedMessageArray[k] += encryptedMessage[i][k]; // adding same row values in a different columns 
                        }
                    }
                }

                string decryptedMessage = string.Join("", decryptedMessageArray);//merging all decrypted codes

                string[] numsps = numsp.Split(' ');

                for (int p = 0; p < numsps.Length; p++)
                {
                    decryptedMessage = decryptedMessage.Insert(Convert.ToInt16(numsps[p]) - 1 + p, " "); // adding spaces in decrypted message
                }

                return string.Join(" ", decryptedMessage);

            }

            catch (Exception ex)
            {
                return "Error :" + ex.Message;
            }
        }
    }
}
