using System;
using System.Collections.Generic;

namespace Sabis.Entities
{
  public class Subject: BaseEntity
  {
    public Subject()
    {
    }
    public string Name
    {
      get;
      set;
    }

    public string Description
    {
      get;
      set;
    }

    public List<Concept> Concepts
    {
      get;
      set;
    }
  }
}
