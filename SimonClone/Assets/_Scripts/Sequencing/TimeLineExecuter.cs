using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeLineExecuter : MonoBehaviour
{
    public UnityEvent timeLineEvent;



    private void OnEnable()
    {
        
        if (timeLineEvent != null)
        { timeLineEvent.Invoke(); }
    }

 

}
