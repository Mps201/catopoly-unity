using UnityEngine;
using Catopoly.Models;
using Catopoly.Views;
using Catopoly.Controllers;

namespace Catopoly.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private CatView catViewPrefab;
        [SerializeField] private Transform catSpawnPoint;

        private CatModel _catModel;
        private CatController _catController;

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _catModel = new CatModel(1, "Барсик", catSpawnPoint.position);

            CatView catView = Instantiate(catViewPrefab, catSpawnPoint.position, Quaternion.identity);

            GameObject controllerObj = new GameObject("CatController");
            _catController = controllerObj.AddComponent<CatController>();
            _catController.Model = _catModel;
            _catController.View = catView;
            _catController.Initialize();
        }
    }
}