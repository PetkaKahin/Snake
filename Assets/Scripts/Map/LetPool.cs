using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class LetPool : MonoBehaviour
    {
        [SerializeField] private Let _let;

        private List<Let> _lets = new List<Let>();

        public Let Get(Vector3 position)
        {
            Let let = _lets.FirstOrDefault(newLet => newLet.gameObject.activeSelf == false);

            if (let == null)
            {
                let = Instantiate(_let, transform);
                _lets.Add(let);
            }

            let.transform.position = position;
            let.gameObject.SetActive(true);

            return let;
        }
    }
}
