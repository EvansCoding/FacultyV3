using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class GraduationService : IGraduationService
    {
        private IDataContext context;

        public GraduationService(IDataContext context)
        {
            this.context = context;
        }

        public List<Training_Process> GetGraduations(string id)
        {
            try
            {
                return context.Training_Processes.Include(x => x.Lecturer).Where(x => x.Lecturer.Id == new Guid(id)).ToList();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Training_Process GetGraduationByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Training_Processes.Include(x => x.Lecturer).Where(x => x.Id == ID).SingleOrDefault( );
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
