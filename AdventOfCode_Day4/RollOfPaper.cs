namespace AdventOfCode_Day4;

internal class RollOfPaper
{
    private List<List<char>> input;
    private int innerGridLength;
    private int outerGridLength;
    public RollOfPaper(List<List<char>> _input)
    { 
        innerGridLength = _input[0].Count;
        outerGridLength = _input.Count;
        input = _input;          
    }

    public int Part2Solution()
    {
        var innerGrid = input[0].Count;
        int result = 0;
        int finalResult = 0;
        List<char> newInnerList = new();
        List<List<char>> newOuterList = new();

        do
        {
            result = 0;
            for (int y = 0; y < outerGridLength; y++)
            {
                newInnerList = new();

                for (int x = 0; x < innerGridLength; x++)
                {
                    if (input[y][x] == '@')
                    {
                        var (adjesentFewerThen4, val) = AreAdjesentFewerThen4(input, x, y);

                        if (adjesentFewerThen4)
                        {
                            result++;
                            newInnerList.Add('.');
                        }
                        else
                        {
                            newInnerList.Add('@');
                        }
                    }
                    else
                    {
                        newInnerList.Add('.');
                    }
                }

                newOuterList.Add(newInnerList);
            }

            finalResult += result;
            input = newOuterList;
            newOuterList = new();
        }
        while (result > 0);

        return finalResult;
    }

    public int Part1Soulution()
    {
        int result = 0;

        for (int y = 0; y < outerGridLength; y++)
        {
            for (int x = 0; x < innerGridLength; x++)
            {
                if (input[y][x] == '@')
                {
                    var (adjesentFewerThen4, val) = AreAdjesentFewerThen4(input, x, y);

                    if (adjesentFewerThen4)
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }
    private (bool, int) AreAdjesentFewerThen4(List<List<char>> input, int x, int y)
    {
        int counter = 0;

        for (int k = -1; k <= 1; k++)
        {
            for (int l = -1; l <= 1; l++)
            {
                int kordinataX = x + l;
                int kordinataY = y + k;

                if (kordinataX < 0 || kordinataY < 0 || (kordinataX == x && kordinataY == y) || kordinataX > innerGridLength-1 || kordinataY > outerGridLength - 1)
                    continue;

                if (input[kordinataY][kordinataX] == '@')
                {
                    counter++;
                }

                if (counter >= 4)
                    break;
            }
        }

        if (counter < 4)
            return (true, counter);

        return (false, counter);
    }
}
