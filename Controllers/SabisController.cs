using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sabis.Data;
using Sabis.Entities;
using Sabis.Model;

namespace Sabis.Controllers
{
	public class SabisController:Controller
  {
    private readonly ISabisRepository _repository;
    public SabisController(ISabisRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [Route("/api/sabis/questions/")]
    public async Task<IActionResult> GetQuestions(int? subjectId = null, int? conceptId=null)
    {
      var questions = await _repository.GetQuestions(subjectId,conceptId);
      if (questions != null) return Ok(questions);
      return NotFound();
    }


    [HttpGet]
    [Route("/api/sabis/subjects")]
    public async Task<IActionResult> GetSubjects()
    {
      var subjects = await _repository.GetSubjects();
      if (subjects != null) return Ok(subjects);
      return NotFound();
    }

    [HttpGet]
    [Route("/api/sabis/concepts")]
    public async Task<IActionResult> GetConcepts(int? subjectId = null)
    {
      var concepts = await _repository.GetConcepts(subjectId);
      if (concepts != null) return Ok(concepts);
      return NotFound();
    }


    [HttpGet]
    [Route("/api/sabis/question/id")]
    public async Task<IActionResult> GetQuestion(int id)
    {
      var question = await _repository.GetQuestionById(id);
      if (question != null) return Ok(question);
      return NotFound();
    }



    [HttpPost]
    [Route("/api/sabis/question/")]
    public async Task<IActionResult> SaveQuestion([FromBody]QuestionViewModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          Question question = model.ToEntity();

          await _repository.SaveQuestion(question);

        }
        else
        {
          return BadRequest(ModelState);
        }
      }
      catch (Exception ex)
      {
        ///Should add a logger
        //TODO: Add logger here, efffft
      }

      return BadRequest("Failed to save new student");
    }

  }//end controller class


}
