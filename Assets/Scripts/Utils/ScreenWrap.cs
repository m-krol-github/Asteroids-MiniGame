using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public abstract class ScreenWrap : MonoBehaviour
    {
        protected virtual void Update()
        {
            PositionLimits();
        }

        protected void PositionLimits()
        {
            float positionX = Mathf.Clamp(transform.position.x, -Values.GameValues.SCREEN_SIZE_X / 2, Values.GameValues.SCREEN_SIZE_X / 2);
            float positionY = Mathf.Clamp(transform.position.y, -Values.GameValues.SCREEN_SIZE_Y / 2, Values.GameValues.SCREEN_SIZE_Y / 2);

            float posX = Mathf.Abs(positionX);
            float posY = Mathf.Abs(positionY);

            Vector3 screenPosition = transform.position;

            if (transform.position.x > posX || transform.position.x < -posX)
            {
                screenPosition.x = -screenPosition.x;
            }

            if (transform.position.y > posY || transform.position.y < -posY)
            {
                screenPosition.y = -screenPosition.y;
            }

            transform.position = screenPosition;
        }
    }
}