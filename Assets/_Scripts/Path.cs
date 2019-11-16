using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();
    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = lineColor;
        Transform[] pathTranforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i<pathTranforms.Length; i++)
        {
            if(pathTranforms[i] != transform)
            {
                nodes.Add(pathTranforms[i]);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 prevNode = Vector3.zero;
            Vector3 currentNode = nodes[i].position;

            if (i > 0)
            {
                prevNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                prevNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(prevNode, currentNode);
            Gizmos.DrawWireSphere(currentNode,0.3f);
        }
    }
}
