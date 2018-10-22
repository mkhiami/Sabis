using System.Collections.Generic;
using System.Threading.Tasks;
using Sabis.Entities;

namespace Sabis.Data
{
    public interface ISabisRepository
    {
        Task<IEnumerable<Answer>> GetAnswers(int? questionId = null);
        Task<Question> GetQuestionById(int id);
        Task<IEnumerable<object>> GetQuestions(int? subjectId = null, int? conceptId = null);
        Task<IEnumerable<Concept>> GetConcepts(int? subjectId = null);

        Task<IEnumerable<Subject>> GetSubjects();
        Task<int> SaveAnswer(Answer answer);
        Task<bool> SaveAsync();
        Task<int> SaveQuestion(Question question);
    }
}