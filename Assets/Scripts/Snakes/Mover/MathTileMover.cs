using System.Collections.Generic;
using UnityEngine;

namespace Snakes
{
    public class MathTileMover : BaseTilesMover
    {
        public MathTileMover(Transform head, List<Transform> tiles) : base(head, tiles) { }

        public override void Move()
        {
            float distance = ((Vector2)Head.position - TilePositions[0]).magnitude;

            if (distance > CircleDiametr)
            {
                Vector2 direction = ((Vector2)Head.position - TilePositions[0]).normalized;

                TilePositions.Insert(0, TilePositions[0] + direction * CircleDiametr);
                TilePositions.RemoveAt(TilePositions.Count - 1);
                distance -= CircleDiametr;
            }

            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].position = Vector2.Lerp(TilePositions[i + 1], TilePositions[i], distance / CircleDiametr);
            }
        }
    }
}
