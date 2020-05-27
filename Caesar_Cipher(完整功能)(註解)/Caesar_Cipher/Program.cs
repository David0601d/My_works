using System;

namespace Caesar_Cipher
{
    class Program
    {

        static void Main(string[] args)
        {
       
            Caesar caesar = new Caesar();        //宣告caesar物件

            caesar.getMode();    //執行方法
            caesar.getMessage();

            //暴力破解模式，跑回圈(跑當前最大的長度)
            if (caesar.MODE == "b" || caesar.MODE == "brute-force") //判斷式不可放方法 會出錯
            {
                for (int key = 1; key <= caesar.get_MAX_KEY_SIZE; key++)                //會用decrypt是因為要回推
                    Console.WriteLine(key.ToString() + " " + caesar.getTranslateMessage("decrypt", caesar.MESSAGE, key));
            }            
            //執行加密or解密模式
            else
            {
                caesar.getKey();  //沒選擇暴力破解，則會被要求輸入Key
                Console.WriteLine(caesar.getTranslateMessage(caesar.MODE, caesar.MESSAGE, caesar.KEY)); //取得類別內的參數，並處理結果
            }
            Console.Read(); //等待使用者輸入資料完畢後按ENTER，才繼續執行接在Read()後面的敘述

        }

    }

}

