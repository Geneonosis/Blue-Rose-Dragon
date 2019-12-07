using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePosition : MonoBehaviour
{
    public int _placePosition = 0;
    public int trackSegmentNumber = 0;
    public int lapNumber = 0;

    public Transform _myPosition; //this will just be transform.position;
    public Transform _destinationLocation;

    [Tooltip("distance information, leave this field blank, for debugging purposes only")]
    [SerializeField] float distanceFromDestinationLocation = 0;

    public void Start()
    {
        _myPosition = transform;

        //TODO: how to I get / update the next position... probably need to access a list of
        //      available nodes and choose from them... JADA might be able to help

        //_destinationLocation = ???
    }

    private void FixedUpdate()
    {
        distanceFromDestinationLocation = Vector3.Distance(_myPosition.position, _destinationLocation.position);
    }

    /// <summary>
    /// Updates the new position from an external class (this is to be used by a parent game object script that would be keeping track of places)
    /// </summary>
    /// <param name="newPosition"></param>
    public void UpdatePosition(int newPosition)
    {
        _placePosition = newPosition;
    }

    /// <summary>
    /// Get the distance that this vehicle is from the goal, to be used by an outside class
    /// </summary>
    /// <returns> the distance between the Player/AI and its destination </returns>
    public float GetDistance()
    {
        return distanceFromDestinationLocation;
    }

    /// <summary>
    /// Get the track segment number that will be used to help the parent class determine placing
    /// </summary>
    /// <returns> track segment that the Player/AI is on </returns>
    public float GetTrackSegment()
    {
        return trackSegmentNumber;
    }

    /// <summary>
    /// Get the lap number to help a parent class determine placement
    /// </summary>
    /// <returns> lap number that the Player/AI is on </returns>
    public float GetLapNumber()
    {
        return lapNumber;
    }
}
