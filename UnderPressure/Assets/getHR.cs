using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class getHR : MonoBehaviour
{
    public GameObject networkobject;

    public List<int> heartrate;
    public List<string> dateTime;
    public List<DateTime> timeList;

    public List<DateTime> DTtimeList;
    public DateTime StartTime;
    public DateTime EndTime;

    // Start is called before the first frame update
    private void Start()
    {
        GetStartTime();
        GetEndTime();
    }


    public void getGraphData()
    {
        Debug.Log("Processing: Start Time is: " + StartTime);

        Debug.Log("Processing: End Time is: " + EndTime);

        getHRWeb GetHRWeb = networkobject.GetComponent<getHRWeb>();
        string resultString = GetHRWeb.hrDT;
        string[] results = resultString.Split(new string[] { "\": ", ", " }, StringSplitOptions.RemoveEmptyEntries);
        int ArraySize = results.Length;

        for (int i = 0; i < ArraySize; i++)
        {
            if ((i + 1) % 2 == 0)
            {

                results[i] = results[i].TrimStart('\"');
                results[i] = results[i].TrimEnd('}');
                results[i] = results[i].TrimEnd('\"');
                //Debug.Log(results[i]);
                int temp = int.Parse(results[i]);
                createHRList(temp);


                //Debug.Log("AS INT: " + temp);
            }
            else
            {
                createDateTimeList(results[i]);
                //Debug.Log("Date and Time: "+ results[i]);


            }
        }

        var datetimeStr = String.Join(",", dateTime.ToArray());
        //Debug.Log("As String: " + datetimeStr);
        string[] dateTimeList = datetimeStr.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        int ArraySizeDT = dateTimeList.Length;
        List<DateTime> testDT = new List<DateTime>();

        for (int i = 0; i < ArraySizeDT; i++)
        {
            if ((i + 1) % 2 == 0)
            {

                //createTimeList(dateTimeList[i]);
                DateTime timeinput = Convert.ToDateTime(dateTimeList[i]);
                //Debug.Log("Datatype: " + timeinput.GetType());
                testDT.Add(timeinput);
                //timeList.Add(timeinput);
                //createDTTimeList(Convert.ToDateTime(dateTimeList[i]));

                //Debug.Log("AS INT: " + temp);
            }
        }
        timeList = testDT;

        //for (int i = 0; i < testDT.Count(); i++)
        //{

        //    Debug.Log("TimeList " + i + ": " + testDT[i]);
        //}


        //for (int i = 0; i < timeList.Count(); i++)
        //{

        //    Debug.Log("TimeList " + i + ": " + timeList[i]);
        //}

        //for (int i = 0; i < heartrate.Count(); i++)
        //{
        //    Debug.Log("heartrate " + i + ": " + heartrate[i]);
        //}

        //Debug.Log("1: " + dateTimeList[0]);
        //Debug.Log("2: " + dateTimeList[1]);
        //Debug.Log("3: " + dateTimeList[2]);
        //Debug.Log("4: " + dateTimeList[3]);
        //Debug.Log("5: " + dateTimeList[4]);
        //Debug.Log("6: " + dateTimeList[5]);
        //Debug.Log("7: " + dateTimeList[6]);
        //Debug.Log("8: " + dateTimeList[7]);



        //Debug.Log("1: " + results[0]);
        //Debug.Log("2: " + results[1]);
        //Debug.Log("3: " + results[2]);
        //Debug.Log("4: " + results[3]);
        //Debug.Log("5: " + results[4]);
        //Debug.Log("6: " + results[5]);
        //Debug.Log("7: " + results[6]);
        //Debug.Log("8: " + results[7]);
        //Debug.Log("last: " + "which is number: " + ArraySize + " " + results[ArraySize - 1]);

        List<int> tempHR = new List<int>();
        for (int i = 0; i < timeList.Count(); i++)
        {
            //Debug.Log("Trimming: Start Time is: " + StartTime);

            //Debug.Log("Trimming: End Time is: " + EndTime);

            if (timeList[i] >= StartTime && timeList[i] <= EndTime)
            {
                Debug.Log("Trimmer: " + heartrate[i]);

                tempHR.Add(heartrate[i]);
            }
            else
            {
                //Debug.Log("value not necessary");
            }
        }

        heartrate = tempHR;
    }

    public void createHRList(int input)
    {
        heartrate.Add(input);
    }

    public void createDateTimeList(String DTinput)
    {
        dateTime.Add(DTinput);
    }

    public void createDTTimeList(DateTime Tinput)
    {
        DTtimeList.Add(Tinput);
    }

    public void GetStartTime()
    {
        StartTime = System.DateTime.Now;
        Debug.Log("Start Time Set to: " + StartTime);
    }

    public void GetEndTime()
    {
        EndTime = System.DateTime.Now;
        Debug.Log("End Time Set to: " + EndTime);
    }

}