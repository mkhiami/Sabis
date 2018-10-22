using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sabis.Entities;

namespace Sabis.Data
{
  public class SabisRepository : ISabisRepository
  {
    private readonly QuestionBankContext _context;
    public SabisRepository(QuestionBankContext context)
    {
      _context = context;
    }

    public async Task<bool> SaveAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<IEnumerable<Question>> GetQuestions(int? subjectId=null, int? conceptId=null)
    {
      return await _context.Questions.Where(question =>
                                            (subjectId == null || question.Concept.SubjectId == subjectId)
                                            &&  (conceptId == null || question.ConceptId == conceptId)
      ).ToListAsync();
    }

    public async Task<IEnumerable<Concept>> GetConcepts(int? subjectId=null)
    {
      return await _context.Concepts.Where(concept=> (subjectId== null || concept.SubjectId  == subjectId)).ToListAsync();
    }


    public async Task<IEnumerable<Subject>> GetSubjects()
    {
      return await _context.Subjects.ToListAsync();
    }

    public async Task<IEnumerable<Answer>> GetAnswers(int? questionId = null)
    {
      return await _context.Answers.Where(answer => (questionId ==null || answer.QuestionId == questionId)).ToListAsync();
    }

    public async Task<Question> GetQuestionById(int id)
    {
      return await _context.Questions.FindAsync(id);
    }

   
   
    public Task<int> SaveQuestion(Question question)
    {
      if (question.Id == 0) _context.Add(question); else _context.Update(question);
      return _context.SaveChangesAsync();
    }


    public Task<int> SaveAnswer(Answer answer)
    {
      if (answer.Id == 0) _context.Add(answer); else _context.Update(answer);
      return _context.SaveChangesAsync();
    }


  }
}
