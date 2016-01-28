namespace LINQdIn.Services
{
    using System;
    using System.Linq;
    using Data.Repository;
    using Models;

    public class SkillsService : ISkillsService
    {
        private IRepository<Skill> skills;

        public SkillsService(IRepository<Skill> skills)
        {
            this.skills = skills;
        }

        public IQueryable<Skill> GetAll()
        {
            return this.skills.All();
        }

        public IQueryable<Skill> Update(int id, Skill skill)
        {
            var targetSkill = this.skills.All().FirstOrDefault(x => x.Id == id);

            targetSkill.Name = skill.Name;

            this.skills.Update(targetSkill);
            this.skills.SaveChanges();

            return this.skills.All();
        }

        public IQueryable<Skill> Add(Skill skill)
        {
            this.skills.Add(skill);
            this.skills.SaveChanges();

            return this.skills.All();
        }

        public IQueryable<Skill> Delete(int id)
        {
            var targetSkill = this.skills.All().FirstOrDefault(x => x.Id == id);

            this.skills.Delete(targetSkill);
            this.skills.SaveChanges();

            return this.skills.All();
        }
    }
}
