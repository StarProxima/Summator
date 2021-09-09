using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Numbers : MonoBehaviour
{
    public InputField input1, input2;
    public GameObject answer;
    public string a = "", b= "", max = "";

    string temp1 = "", temp2 = "";
    int t1, t2, a2, b2;
    void Start()
    {
        a = to_binary_string(0);
        b = to_binary_string(0);
        max = to_binary_string(0);
        //Debug.Log(a);
    }


    void FixedUpdate()
    {

        if (input1.textComponent.text != "" && input1.textComponent.text != "-") 
        {
            int temp = System.Convert.ToInt32(input1.textComponent.text);
            if (Math.Abs(temp) > 65535) 
            {   
                if (temp > 0){
                    if (Math.Abs(temp) > 99999) input1.text = input1.text.Remove(5);
                    else input1.text = input1.text.Remove(4);
                }
                else {
                    if (Math.Abs(temp) > 99999) input1.text = input1.text.Remove(6);
                    else input1.text = input1.text.Remove(5); 
                }
                
            }
            else a = to_binary_string(temp);
        }
        else a =  to_binary_string(0);
        if (input2.textComponent.text != "" && input2.textComponent.text != "-") 
        {
            int temp = System.Convert.ToInt32(input2.textComponent.text);
            if (Math.Abs(temp) > 65535) 
            { 
                if (temp > 0){
                    if (Math.Abs(temp) > 99999) input2.text = input2.text.Remove(5);
                    else input1.text = input1.text.Remove(4);
                }
                else {
                    if (Math.Abs(temp) > 99999) input2.text = input2.text.Remove(6);
                    else input2.text = input2.text.Remove(5); 
                }
            }
            else b = to_binary_string(temp);
        }
        else b =  to_binary_string(0);



        if (input1.textComponent.text != "-" && input2.textComponent.text != "-")
        {
            
            if (input1.textComponent.text == "") a2 = 0;
            else a2 = Math.Abs(System.Convert.ToInt32(input1.textComponent.text));
            if (input2.textComponent.text == "") b2 = 0;
            else b2 = Math.Abs(System.Convert.ToInt32(input2.textComponent.text));

            if (a2 > b2)
                max = a;
            else max = b;

            if (input1.textComponent.text != "" && input2.textComponent.text != "")
            {
                if (input1.textComponent.text[0] == '-' && input2.textComponent.text[0] == '-' && (a2 == b2))
                max = to_binary_string(-1);
                else if (a2 == b2) max = to_binary_string(1);
            }
            
        } 
        



        if (input1.textComponent.text != "" && input1.textComponent.text != "-") t1 = System.Convert.ToInt32(input1.textComponent.text);
        else t1 = 0;
        if (input2.textComponent.text != "" && input2.textComponent.text != "-") t2 = System.Convert.ToInt32(input2.textComponent.text);
        else t2 = 0;

        answer.GetComponent<Text>().text =  ((t1 + t2)%65536) + "";


        
    }

    string to_binary_string(int n)
    {
        
        string result = "";
        if (n >= 0)
        {
            do
            {
                result = ("" + (n % 2)) + result;
                n = n / 2;
            } while (n > 0);
            for(int i = result.Length; i < 17; i++)
                result = "0" + result;
            return result;
        }
            
        else
        {   
            n+=1;
            n = -n;
            do
            {
                result = ("" + (n+1) % 2) + result;
                n = n / 2;
            } while (n > 0);
            for(int i = result.Length; i < 17; i++)
                result = "1" + result;
            return result;
        }
    }
}
