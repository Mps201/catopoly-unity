using UnityEngine;

namespace Catopoly.Core
{
    public class GridVisualizer : MonoBehaviour
    {
        [SerializeField] private int gridSize = 30;
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private Color gridColor = Color.white;

        private void OnDrawGizmos()
        {
            Gizmos.color = gridColor;

            for (int x = 0; x <= gridSize; x++)
            {
                Vector3 start = new Vector3(x * cellSize, 0.01f, 0);
                Vector3 end = new Vector3(x * cellSize, 0.01f, gridSize * cellSize);
                Gizmos.DrawLine(start, end);
            }

            for (int z = 0; z <= gridSize; z++)
            {
                Vector3 start = new Vector3(0, 0.01f, z * cellSize);
                Vector3 end = new Vector3(gridSize * cellSize, 0.01f, z * cellSize);
                Gizmos.DrawLine(start, end);
            }
        }
    }
}