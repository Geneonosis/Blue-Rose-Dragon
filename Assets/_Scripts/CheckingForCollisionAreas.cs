/*******************************************************
 * Author: Gene Tigner
 * Date: 10/10/2019
 * =====================================================
 * Purpose: 
 *  This Class ensures that all race track bounding
 * colliders are cacheable and labeled correctly. The 
 * results are only displayable in DEBUG mode in UNITY.
 * 
 * Additionally this class provides a getter for both
 * arrays in the off chance that there is need for
 * a cache of all colliders.
 *******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingForCollisionAreas : MonoBehaviour
{
    private GameObject[] _listOfColliders;
    private GameObject[] _listOfCollidersNotTagged;
    private int _totalColliders = 0;
    private int _noAppropriateTagTotal = 0;

    public GameObject[] ListOfColliders { get => _listOfColliders; set => _listOfColliders = value; }
    public GameObject[] ListOfCollidersNotTagged { get => _listOfCollidersNotTagged; set => _listOfCollidersNotTagged = value; }

    void Start()
    {
        //check all the children of the parent game object
        //and collect a count of all game objects with the
        //tag and also count ones without the tag
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Equals("NoEntry"))
            {
                _totalColliders++;
            }
            else
            {
                _noAppropriateTagTotal++;
            }
        }

        ListOfColliders = new GameObject[_totalColliders];
        ListOfCollidersNotTagged = new GameObject[_noAppropriateTagTotal];
        int i = 0;
        int j = 0;
        
        //cache each tagged and not tagged game object in their
        //associated arrays
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag.Equals("NoEntry"))
            {
                ListOfColliders[i] = child.gameObject;
                i++;
            }
            else
            {
                ListOfCollidersNotTagged[j] = child.gameObject;
                j++;
            }
        }
    }
}
