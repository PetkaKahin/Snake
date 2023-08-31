using System.Collections.Generic;
using UnityEngine;

namespace Snakes
{
    public abstract class BaseTilesMover
    {
        protected readonly Transform Head;

        protected List<Transform> Tiles;

        protected List<Vector2> TilePositions = new List<Vector2>();

        protected float CircleDiametr;

        public BaseTilesMover(Transform head, List<Transform> tiles)
        {
            Head = head;
            Tiles = tiles;
            CircleDiametr = Head.localScale.x;

            TilePositions.Add(Head.position);

            foreach (Transform tile in Tiles)
                TilePositions.Add(tile.position);
        }

        public abstract void Move();
    }
}