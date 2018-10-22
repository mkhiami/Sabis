using System;
namespace Sabis.Entities
{
	public class Answer: BaseEntity
  {
    public Answer()
    {
    }

    public string Body {
      get;
      set;
    }

    public int Order
    {
      get;
      set;
    }

    public int QuestionId
    {
      get;
      set;
    }

    public Question Question
    {
      get;
      set;
    }

  }
}
