using System;
using System.ComponentModel.DataAnnotations;
using Sabis.Entities;

namespace Sabis.Model
{
  public class QuestionViewModel
  {
    public QuestionViewModel()
    {
    }

    [Required]

    public int ConceptId
    {
      get;
      set;
    }
    [Required]

    public string Body
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }

    public int Order
    {
      get;
      set;
    }


    public int Id
    {
      get;
      set;
    }

    //TODO: add mapping using Automapper or ?
    internal Question ToEntity()
    {
      return new Question(){ Body = this.Body, Description = this.Description, Id= this.Id, ConceptId= this.ConceptId};
    }
  }
}
