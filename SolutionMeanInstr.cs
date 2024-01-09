using UnityEngine;
using UnityEngine.UI;
using Accord.Statistics.Distributions.Univariate;

public class SolutionMeanInstr : MonoBehaviour
{
    //Samples from an exponential distribution
    public void Sample()
    {
        var ed = new ExponentialDistribution(rate: 10);
        InstructionsBoardManager.sample = ed.Generate(10);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}