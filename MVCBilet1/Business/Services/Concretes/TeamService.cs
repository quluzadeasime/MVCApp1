using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IWebHostEnvironment _environment;
        public TeamService(ITeamRepository teamRepository, IWebHostEnvironment environment)
        {
            _teamRepository = teamRepository;
            _environment = environment;
        }

        public void Add(Team team)
        {
            if (team == null) throw new TeamNullException("", "Team bos ola bilmez!!");
            if (!team.PhotoFile.FileName.Contains("image/")) throw new ContentTypeException("", "File contenti sehvdir");
            if (team.PhotoFile.Length > 2097152) throw new FileSizeException("", "File olcusu max 2 mb ola biler!");

            string path = _environment.WebRootPath + @"\upload\" + team.PhotoFile.FileName;
            using(FileStream filename =new FileStream(path, FileMode.Create))
            {
                team.PhotoFile.CopyTo(filename);
            }
            team.ImgUrl = team.PhotoFile.FileName;
            _teamRepository.Add(team);
            _teamRepository.Commit();
        }       

        public void Delete(int id)
        {
            var existTeam = _teamRepository.Get(x => x.Id == id);

            if (existTeam == null) throw new NullReferenceException("Id bos ola bilmez!");
            string path = _environment.WebRootPath + @"\upload\" + existTeam.PhotoFile.FileName;

            if (!File.Exists(path))
                throw new FileNotFoundException("PhotoFile", "File yoxdur");

            File.Delete(path);
            _teamRepository.Delete(existTeam);
            _teamRepository.Commit();
        }

        public List<Team> GetAll(Func<Team, bool> func = null)
        {
            return _teamRepository.GetAll(func);
        }

        public Team GetTeam(Func<Team, bool> func = null)
        {
            return _teamRepository.Get(func);
        }

        public void Update()
        {

        }

        [HttpPost]
        public void Update(int id, Team team)
        {
            var existTeam = _teamRepository.Get(x => x.Id == id);
            if (existTeam == null) throw new TeamNotFoundException("", "Team yoxdur");
           
            if (team == null) throw new TeamNullException("", "Team bos ola bilmez!!");
            if(team.PhotoFile != null)
            {
                if (!team.PhotoFile.FileName.Contains("image/")) throw new ContentTypeException("", "File contenti sehvdir");
                if (team.PhotoFile.Length > 2097152) throw new FileSizeException("", "File olcusu max 2 mb ola biler!");

                string path = _environment.WebRootPath + @"\upload\" + team.PhotoFile.FileName;
                using (FileStream filename = new FileStream(path, FileMode.Create))
                {
                    team.PhotoFile.CopyTo(filename);
                }
                existTeam.ImgUrl = team.ImgUrl;
            }
            existTeam.Fullname = team.Fullname;
            existTeam.Position = team.Position;
            
        }
    }
}
