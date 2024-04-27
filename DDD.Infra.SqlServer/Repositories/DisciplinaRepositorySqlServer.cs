using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SqlServer.Repositories
{
    public class DisciplinaRepositorySqlServer : IDisciplinaRepository
    {

        private readonly SqlServerContext _context;

        public DisciplinaRepositorySqlServer(SqlServerContext context)
        {
            _context = context;
        }

        public Disciplina GetDisciplinaById(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }

        public void InsertDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Entry(disciplina).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Set<Disciplina>().Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
