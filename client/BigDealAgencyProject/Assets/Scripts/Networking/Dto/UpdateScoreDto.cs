using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreDto
{
    public long id;
    public int score;

    public UpdateScoreDto(long id, int score)
    {
        this.id = id;
        this.score = score;
    }
}
