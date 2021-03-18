using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    [CreateAssetMenu]
    public class GameTileContentFactory : ScriptableObject
    {
        [SerializeField] private GameTileContent destinationPrefab;
        [SerializeField] private GameTileContent emptyPrefab;
        
        [SerializeField] private GameTileContent wallPrefab;

        public void Reclaim(GameTileContent content)
        {
            Destroy(content.gameObject);
        }

        public GameTileContent Get(GameTileContentType type)
        {
            switch (type)
            {
                case GameTileContentType.Destination:
                    return Get(destinationPrefab);
                case GameTileContentType.Empty:
                    return Get(emptyPrefab);
                case GameTileContentType.Wall:
                    return Get(wallPrefab);
            }
        
            return null;
        }
        
        private GameTileContent Get(GameTileContent prefab)
        {
            var instance = Instantiate(prefab);
            instance.OriginFactory = this;
            MoveToFactoryScene(instance.gameObject);
            return instance;
        }
        
        private Scene _contentScene;
        
         private void MoveToFactoryScene(GameObject o)
         {
             if (!_contentScene.isLoaded)
             {
                 if (Application.isEditor)
                 {
                     _contentScene = SceneManager.GetSceneByName(name);
                     if (!_contentScene.isLoaded)
                     {
                         _contentScene = SceneManager.CreateScene(name);
                     }
                 }
                 else
                 {
                     _contentScene = SceneManager.CreateScene(name);
                 }
             }
             SceneManager.MoveGameObjectToScene(o, _contentScene);
         }
    }
}
