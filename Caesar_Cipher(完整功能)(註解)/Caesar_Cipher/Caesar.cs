using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    class Caesar
    {
      
        static string SYMBOLS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        int MAX_KEY_SIZE = SYMBOLS.Length;
        private string mode, message;
        int key;
        string symbolLetter;
        int symbolIndex = 0;


        //重要：Ctrl + k + d 排版
        //重要：一定要public，否則無法呼叫該方法
        //重要：當執行WriteLine()時，程式會停頓，等待使用者輸入。 若將詢問句和mode放到迴圈外將會被洗版
        public string getMode()
        {
            while (true)
            {
                Console.WriteLine("Do you wish to encrypt or decrypt or brute-force a message?");
                mode = Console.ReadLine().ToLower();
                if (mode == "e" || mode == "encrypt" || mode == "d" || mode == "decrypt" || mode == "b" || mode == "brute-force")
                    break;
                else
                    Console.WriteLine("Enter either 'encrypt' or 'e' or 'decrypt' or 'd' or 'brute-force' or 'b'.");
            }
            return mode;
        }

        public string getMessage()
        {
            Console.WriteLine("Enter your message:");
            message = Console.ReadLine();
            return message;
        }

        public int getKey()
        {
            while (true)
            {
                Console.WriteLine("Enter the key number (1-52)"); // XXX    之後要改    XXX
                key = Int32.Parse(Console.ReadLine());
                if (key >= 1 && key <= MAX_KEY_SIZE)
                {
                    Console.WriteLine("Your translated is：");
                    break;
                }
                  
            }
            return key;
        }

        public string getTranslateMessage(string mode, string message, int key)
        {

            string translated = "";
            //解密模式，改變key 
            if (mode == "d" || mode == "decrypt")
                key *= -1;
          
            //利用迴圈一個個取得字元
            for (int i = 0; i < message.Length; i++)
            {
                //取得當前的字元(起始索引值, 長度) 
                symbolLetter = message.Substring(i, 1);
                //取得對應到的索引值
                symbolIndex = SYMBOLS.IndexOf(symbolLetter); 

                //在SYMBOLS找不到，傳-1，字串存入translated ; 找到，更改索引值並且存入translated
                if (symbolIndex == -1)
                {
                    translated += symbolLetter; 
                    continue;//這裡需要直接跳到下一次迴圈，否則會執行到 translated += SYMBOLS[symbolIndex]這句，這樣會超出索引值
                } 
                else
                {
                    symbolIndex += key;
                    if (symbolIndex > MAX_KEY_SIZE - 1) //-1因為要把它當成索引值
                        symbolIndex -= MAX_KEY_SIZE;
                    else if (symbolIndex < 0)
                        symbolIndex += MAX_KEY_SIZE;        
                }

                translated += SYMBOLS[symbolIndex];
            }
            return translated;
        }


        public string MODE
        {
            get { return mode; }
        }

        public string MESSAGE
        {
            get { return message; }
        }

        public int KEY
        {
            get { return key; }
        }

        public int get_MAX_KEY_SIZE
        { 
            get { return MAX_KEY_SIZE; }
        }

    }

}

