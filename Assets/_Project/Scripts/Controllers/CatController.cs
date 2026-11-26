using UnityEngine;
using Catopoly.Core;
using Catopoly.Models;
using Catopoly.Views;

namespace Catopoly.Controllers
{
    public class CatController : BaseController
    {
        private CatModel _catModel;
        private CatView _catView;

        public override void Initialize()
        {
            _catModel = Model as CatModel;
            _catView = View as CatView;

            if (_catModel != null && _catView != null)
            {
                _catView.Bind(_catModel);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveCatToClickPosition();
            }
        }

        private void MoveCatToClickPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("Walls");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log($"Raycast hit: {hit.collider.name}, tag: {hit.collider.tag}");

                if (hit.collider.CompareTag("Floor"))
                {
                    _catModel?.MoveTo(hit.point);
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing");
            }
        }
    }
}