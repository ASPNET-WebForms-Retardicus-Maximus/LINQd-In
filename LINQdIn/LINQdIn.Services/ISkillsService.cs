namespace LINQdIn.Services
{
    using System.Linq;
    using Models;

    public interface ISkillsService
    {
        IQueryable<Skill> GetAll();

        IQueryable<Skill> Update(int id, Skill skill);

        IQueryable<Skill> Add(Skill skill);

        IQueryable<Skill> Delete(int id);
    }
}
