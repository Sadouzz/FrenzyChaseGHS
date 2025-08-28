using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoliceRoad : MonoBehaviour
{
    public Color lineColor;
    public Transform[] nodes;

    void OnDrawGizmos()
    {
    	Gizmos.color = lineColor;

    	nodes = new Transform[this.transform.childCount];
    	for(int i = 0; i < nodes.Length; i++)
    	{  nodes[i] = this.transform.GetChild(i);
        }
    	

    	for(int i = 0; i < nodes.Length; i++)
    	{
    		Vector3 currentNode = nodes[i].position;
    		Vector3 previousNode = Vector3.zero;

    		if(i > 0)
    		{
    			previousNode = nodes[i - 1].position;
    		}
    		else if(i == 0 && nodes.Length > 1)
    		{
    			previousNode = nodes[nodes.Length - 1].position;
    		}

    		Gizmos.DrawLine(previousNode, currentNode);
    		Gizmos.DrawWireSphere(currentNode, 2);
    	}
    }
       
}
