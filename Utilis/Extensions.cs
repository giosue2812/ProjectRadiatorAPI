using ProjectRadiator.DTO;
using ProjectRadiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Utilis
{
    public static class Extensions
    {
        public static ProjectShortDTO ToProjectShortDTO(this Project project)
        {
            if (project == null) return null;

            ProjectShortDTO result = new ProjectShortDTO();


            result.Id = project.IdProject;
            result.Title = project.Title;
            result.Description = project.Description;
            result.Society = project.IdSocietyNavigation.ToSocietyShortDTO();
            result.TypeStages = project.ProjectStage.FirstOrDefault().IdStageNavigation.StagesTypeStages.FirstOrDefault().IdStagesNavigation.ToTypeStagesShortDTO();

            return result;
        }
        public static SocietyShortDTO ToSocietyShortDTO(this Society society)
        {
            if (society == null) return null;

            return new SocietyShortDTO
            {
                Name = society.Name
            };
        }

        public static TypeStagesShortDTO ToTypeStagesShortDTO(this TypeStages typeStages)
        {
            if (typeStages == null) return null;

            return new TypeStagesShortDTO
            {
                TypeStages1 = typeStages.TypeStages1
            };
        }
    }
} 