using AppWEB.Data.Repositório.Interface;
using AppWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppWEB.Data.Repositório
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public AlunoRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Add(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }

        public List<AlunoModel> BuscarAlunos()
        {
            return _jovemProgramadorContexto.Aluno.ToList();
        }

        public void EditarAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Update(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }

        public AlunoModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        

        
    }
}
