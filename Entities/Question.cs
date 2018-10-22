using System;
namespace Sabis.Entities
{
	public class Question: BaseEntity
  {
    public Question()
    {
    }

    public string Description {
      get;
      set;
    }

    public string Body
    {
      get;
      set;
    }

    public int Order
    {
      get;
      set;
    }

    public int ConceptId
    {
      get;
      set;
    }

    public Concept Concept
    {
      get;
      set;
    }
   
  }
}
