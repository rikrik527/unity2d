using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void MovementDelegate(float xInput, float yInput, bool isWalking, bool isRunning, bool isSprinting, bool isSlowingDown, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool idleLeft, bool idleRight);


public static class EventHandle
{
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (InventoryUpdatedEvent != null)
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
    }



    // movement event
    public static event MovementDelegate MovementEvent;

    // movement Event call for publisher

    public static void CallMovementEvent(float xInput, float yInput, bool isWalking, bool isRunning, bool isSprinting, bool isSlowingDown, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool idleLeft, bool idleRight)
    {
        if (MovementEvent != null)
            MovementEvent(xInput, yInput, isWalking, isRunning, isSprinting, isSlowingDown, isIdle, isCarrying, toolEffect, idleLeft, idleRight);
    }
}
