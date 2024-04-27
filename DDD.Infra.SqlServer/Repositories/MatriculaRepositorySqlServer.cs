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
    public class MatriculaRepositorySqlServer : IMatriculaRepository
    {

        private readonly SqlServerContext _context;

        public MatriculaRepositorySqlServer(SqlServerContext context)
        {
            _context = context;
        }

       

        public Matricula GetMatriculaById(int id)
        {
            return _context.Matriculas.Find(id);
        }

        public List<Matricula> GetMatriculas()
        {
            return _context.Matriculas.ToList();
        }

        public Matricula InsertMatricula(int idAluno, int idDisciplina)
        {
            var aluno = _context.Alunos.First(i => i.UserId == idAluno);
            var disciplina = _context.Disciplinas.First(i => i.DisciplinaId == idDisciplina);

            var newMatricula = new Matricula
            {
                Aluno = aluno,
                Disciplina = disciplina
            };

            try
            {

                _context.Add(newMatricula);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return newMatricula;
        }

        public void UpdateMatricula(Matricula matricula)
        {
            try
            {
                _context.Entry(matricula).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMatricula(Matricula matricula)
        {
            try
            {
                _context.Set<Matricula>().Remove(matricula);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
