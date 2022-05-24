using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] plotsPre;

    GameObject[] plot1;
    GameObject[] plot2;
    GameObject[] plot3;
    GameObject[] plot4;
    GameObject[] plot5;
    GameObject[] plot6;
    GameObject[] plot7;
    GameObject[] plot8;
    GameObject[] plot9;
    GameObject[] plot10;
    GameObject[] plot11;
    GameObject[] plot12;
    GameObject[] plot13;
    GameObject[] plot14;

    GameObject[] targetpool;

    void Awake()
    {

        plot1 = new GameObject[8];
        plot2 = new GameObject[8];
        plot3 = new GameObject[8];
        plot4 = new GameObject[8];
        plot5 = new GameObject[8];
        plot6 = new GameObject[8];
        plot7 = new GameObject[8];
        plot8 = new GameObject[8];
        plot9 = new GameObject[8];
        plot10 = new GameObject[8];
        plot11 = new GameObject[8];
        plot12 = new GameObject[8];
        plot13 = new GameObject[8];
        plot14 = new GameObject[8];


        Generate();
    }
    void Generate()
    {
        for (int index = 0; index < plot1.Length; index++)
        {
            plot1[index] = Instantiate(plotsPre[0]);
            plot1[index].SetActive(false);
        }

        for (int index = 0; index < plot2.Length; index++)
        {
            plot2[index] = Instantiate(plotsPre[1]);
            plot2[index].SetActive(false);
        }

        for (int index = 0; index < plot3.Length; index++)
        {
            plot3[index] = Instantiate(plotsPre[2]);
            plot3[index].SetActive(false);
        }

        for (int index = 0; index < plot4.Length; index++)
        {
            plot4[index] = Instantiate(plotsPre[3]);
            plot4[index].SetActive(false);
        }

        for (int index = 0; index < plot5.Length; index++)
        {
            plot5[index] = Instantiate(plotsPre[4]);
            plot5[index].SetActive(false);
        }

        for (int index = 0; index < plot6.Length; index++)
        {
            plot6[index] = Instantiate(plotsPre[5]);
            plot6[index].SetActive(false);
        }

        for (int index = 0; index < plot7.Length; index++)
        {
            plot7[index] = Instantiate(plotsPre[6]);
            plot7[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot8.Length; index++)
        {
            plot8[index] = Instantiate(plotsPre[7]);
            plot8[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot9.Length; index++)
        {
            plot9[index] = Instantiate(plotsPre[8]);
            plot9[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot10.Length; index++)
        {
            plot10[index] = Instantiate(plotsPre[9]);
            plot10[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot11.Length; index++)
        {
            plot11[index] = Instantiate(plotsPre[10]);
            plot11[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot12.Length; index++)
        {
            plot12[index] = Instantiate(plotsPre[11]);
            plot12[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot13.Length; index++)
        {
            plot13[index] = Instantiate(plotsPre[12]);
            plot13[index].SetActive(false);
        }        
        
        for (int index = 0; index < plot14.Length; index++)
        {
            plot14[index] = Instantiate(plotsPre[13]);
            plot14[index].SetActive(false);
        }        
        

    }
    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "Plane0":
                targetpool = plot1;
                break;

            case "Plane1":
                targetpool = plot2;
                break;

            case "Plane2":
                targetpool = plot3;
                break;

            case "Plane3":
                targetpool = plot4;
                break;

            case "Plane4":
                targetpool = plot5;
                break;

            case "Plane5":
                targetpool = plot6;
                break;

            case "Plane6":
                targetpool = plot7;
                break;
            
            case "Plane7":
                targetpool = plot8;
                break;

            case "Plane8":
                targetpool = plot9;
                break;

            case "Plane9":
                targetpool = plot10;
                break;

            case "Plane10":
                targetpool = plot11;
                break;

            case "Plane11":
                targetpool = plot12;
                break;

            case "Plane12":
                targetpool = plot13;
                break;

            case "Plane13":
                targetpool = plot14;
                break;

        }
        for (int index = 0; index < targetpool.Length; index++)
        {
            if (!targetpool[index].activeSelf)
            {
                targetpool[index].SetActive(true);
                return targetpool[index];
            }
        }
        return null;
    }
}
