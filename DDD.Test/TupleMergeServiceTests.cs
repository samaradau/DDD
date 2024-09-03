namespace DDD.Test;

public class TupleMergeServiceTests
{
    private readonly TupleMergeService sut = new();

    [Fact]
    public void GetMergedTuples_ReturnsValidResult_WhenAllMerged()
    {
        (int, int)[] tuples = [(1,2), (2,3), (3, 4)];
        (int, int)[] expected = [(1,4)];

        var actual = sut.GetMergedTuples(tuples);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetMergedTuples_ReturnsValidResult_WhenMiddleLeft()
    {
        (int, int)[] tuples = [(1,2), (3,3), (3, 4)];
        (int, int)[] expected = [(1,2), (3,4)];
        
        var actual = sut.GetMergedTuples(tuples);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetMergedTuples_ReturnsValidResult_WhenNothingMerged()
    {
        (int, int)[] tuples = [(1,2), (3,4), (5, 6)];
        (int, int)[] expected = [(1,2), (3,4), (5, 6)];
        
        var actual = sut.GetMergedTuples(tuples);

        Assert.Equal(expected, actual);
    }
}

public class TupleMergeService
{
    public (int, int)[] GetMergedTuples((int, int)[] tuples)
    {
        List<(int, int)> res = [];
        var current = tuples[0];

        for (int i = 1; i < tuples.Length; i++)
        {
            (int, int) tuple = tuples[i];

            if (current.Item2 == tuple.Item1) {
                current = (current.Item1, tuple.Item2);
            }
            else {
                res.Add(current);
                current = tuple;
            }
        }

        res.Add(current);

        return res.ToArray();
    }
}