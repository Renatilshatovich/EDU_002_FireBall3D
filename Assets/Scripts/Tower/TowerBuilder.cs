using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;

    private List<Block> _blocks;

    private void Start() {
        Build();
    }

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform ceurrentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(ceurrentPoint);
            _blocks.Add(newBlock);
            ceurrentPoint = newBlock.transform;
        }

        return _blocks;
    }
    
    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y/2 + _block.transform.localScale.y/2, _buildPoint.position.z);
    }
}
