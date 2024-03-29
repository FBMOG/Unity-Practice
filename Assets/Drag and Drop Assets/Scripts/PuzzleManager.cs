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
    public AudioSource audioSource;

    private List<PuzzlePiece> spawnedPieces;
    public Canvas endOfLevelCanvas;

    void Start(){
        Spawn();
    }

    void Spawn() {
        var randomSet = slotPrefabs.ToList();
        spawnedPieces = new List<PuzzlePiece>();

        for(int i = 0; i < randomSet.Count; i++){
            var spawnedSlot = Instantiate(randomSet[i], slotParent.GetChild(i).position, Quaternion.identity);
        
            var spawnedPiece =  Instantiate(_piecePrefab, pieceParent.GetChild((i+2)%4).position, Quaternion.identity);
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
        audioSource.Stop();
        endOfLevelCanvas.gameObject.SetActive(true);

    }
}
