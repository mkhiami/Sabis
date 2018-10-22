using System;
using System.Collections.Generic;

namespace Sabis.Entities
{
	public class Concept:BaseEntity
  {
    public Concept()
    {
    }

    public string Number
    {
      get;
      set;
    }

    public string Description
    {
      get;
      set;
    }
    public int SubjectId
    {
      get;
      set;
    }

    public Subject Subject
    {
      get;
      set;
    }

    public List<Question> Questions
    {
      get;
      set;
    }
  }
}
