using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform slotParent, pieceParent;

    private List<PuzzlePiece> spawnedPieces;

    void Start(){
        Spawn();
    }

    void Spawn() {
        var randomSet = slotPrefabs.OrderBy(s=>Random.value).Take(3).ToList();
        spawnedPieces = new List<PuzzlePiece>();

        for(int i = 0; i < randomSet.Count; i++){
            var spawnedSlot = Instantiate(randomSet[i], slotParent.GetChild(i).position, Quaternion.identity);
        
            var spawnedPiece =  Instantiate(_piecePrefab, pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
            spawnedPieces.Add(spawnedPiece);
        }
    }

    void Update() {
        if (spawnedPieces.All(p => p.IsInCorrectSlot)) {
            ChangeScene();
        }
    }

    void ChangeScene() {
        
        SceneManager.LoadScene("Start Menu");
    }
}
