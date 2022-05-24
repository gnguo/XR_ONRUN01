using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlotSpanwer : MonoBehaviour
{
    private int initAmount = 7;
    private float plotSize = 60f;
    private float xPosLeft = -24.21f;
    private float xPosRight = 24.21f;
    private float lastZPos = -45f;

    public string[] plots;

    public ObjectManager objectManager;

    void Awake()
    {     
        plots = new string[]{ "Plane0", "Plane1", "Plane2",
                              "Plane3", "Plane4","Plane5","Plane6",
                              "Plane7", "Plane8","Plane9","Plane10",
                              "Plane11", "Plane12","Plane13"};

       
    }

    private void Start()
    {
      for (int i = 0; i < initAmount; i++)
      {
          SpawnPlot();
     
      }
    }

    public void SpawnPlot()
    {
        StartCoroutine(SpawnPlotCoroutine());
    }

    IEnumerator SpawnPlotCoroutine()
    {     
        int ranplots = Random.Range(0, 13);
        float zPos = lastZPos + plotSize;

        GameObject plotL = objectManager.MakeObj(plots[ranplots]);
        plotL.transform.position = new Vector3(xPosLeft, 0.025f, zPos);
        plotL.transform.rotation = plotL.transform.rotation;

        GameObject plotR = objectManager.MakeObj(plots[ranplots]);
        plotR.transform.position = new Vector3(xPosRight, 0.025f, zPos);
        plotR.transform.rotation = new Quaternion(0, 180, 0, 0);


        lastZPos += plotSize;

        yield return new WaitForSeconds(20f);

        plotL.SetActive(false);
        plotR.SetActive(false);


    }


}
