using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Summator : MonoBehaviour
{
    public GameObject discharge1, discharge2, line1, line2, line3, line4, lamp, polsum;
    public GameObject a, b, cl, co, sum;
    string temp1 = "", temp2 = "", temp;
    public int index;
    void FixedUpdate()
    {
        string a_temp = Camera.main.GetComponent<Numbers>().a;
        string b_temp = Camera.main.GetComponent<Numbers>().b;

         //Расставляем разряды
        if (temp1 !=  Camera.main.GetComponent<Numbers>().a || temp2 != Camera.main.GetComponent<Numbers>().b)
        {
            discharge1.GetComponent<Text>().text = a_temp[17-index] + "";
            discharge2.GetComponent<Text>().text = b_temp[17-index] + "";
        }

        //Значения полусумматора
        a.GetComponent<Text>().text = a_temp[17-index] + "";
        b.GetComponent<Text>().text = b_temp[17-index] + "";
        if (polsum != null)
            cl.GetComponent<Text>().text = polsum.GetComponent<Summator>().co.GetComponent<Text>().text + "";
        sum.GetComponent<Text>().text = (((System.Convert.ToInt32(a_temp[17-index] + "")) +
                                         (System.Convert.ToInt32(b_temp[17-index] + "")) +
                                         (System.Convert.ToInt32(cl.GetComponent<Text>().text))) % 2) + "";
        co.GetComponent<Text>().text = (((System.Convert.ToInt32(a_temp[17-index] + "")) +
                                         (System.Convert.ToInt32(b_temp[17-index] + "")) +
                                         (System.Convert.ToInt32(cl.GetComponent<Text>().text))) / 2) + "";
        //Покраска линий
        if (a.GetComponent<Text>().text == "1") line1.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.0f, 0.0f, 1);
        else line1.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);

        if (b.GetComponent<Text>().text == "1") line2.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.0f, 0.0f, 1);
        else line2.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);

        if (line3!= null)
        if (co.GetComponent<Text>().text == "1") line3.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.0f, 0.0f, 1);
        else line3.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);

        if (sum.GetComponent<Text>().text == "1") line4.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.0f, 0.0f, 1);
        else line4.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);                                

        //Включение/выключение лампочки
        if (sum.GetComponent<Text>().text == "1")
            lamp.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.855f, 0.333f, 1);
        else 
            lamp.GetComponent<SpriteRenderer>().material.color = new Color(0.9294f, 0.9294f, 0.9294f, 1);

        //Лапочка последнего разряда
        if (index == 17 && Camera.main.GetComponent<Numbers>().max[0] == '1')
        {
            lamp.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.855f, 0.333f, 1);
            for (int i = 1; i < 17; i++)
            GameObject.Find("Text (" + (i + "") + ")" ).GetComponent<Text>().enabled = false;;
        }
            
        if (index == 17 && Camera.main.GetComponent<Numbers>().max[0] == '0')
        {
            lamp.GetComponent<SpriteRenderer>().material.color = new Color(0.9294f, 0.9294f, 0.9294f, 1);
            line4.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
            for (int i = 1; i < 17; i++)
                GameObject.Find("Text (" + (i + "") + ")" ).GetComponent<Text>().enabled = true;
        }
            
        temp1 = Camera.main.GetComponent<Numbers>().a;
        temp2 = Camera.main.GetComponent<Numbers>().b;
    }
}
