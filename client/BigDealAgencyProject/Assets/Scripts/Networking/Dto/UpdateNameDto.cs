using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNameDto
{
    public long id;
    public string name;

    public UpdateNameDto(long id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
