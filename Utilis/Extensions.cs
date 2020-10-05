using ProjectRadiator.DTO;
using ProjectRadiator.DTO.Mettings;
using ProjectRadiator.DTO.Millestones;
using ProjectRadiator.DTO.Peoples;
using ProjectRadiator.DTO.Projects;
using ProjectRadiator.DTO.Stages;
using ProjectRadiator.DTO.TypeFollows;
using ProjectRadiator.Models;
using System.Linq;

namespace ProjectRadiator.Utilis
{
    public static class Extensions
    {
        public static ProjectShortDTO ToProjectShortDTO(this Project project)
        {
            if (project == null) return null;

            ProjectShortDTO result = new ProjectShortDTO
            {
                Id = project.IdProject,
                Title = project.Title,
                Description = project.Description,
                Society = project.IdSocietyNavigation.Name
            };

            if (project.ProjectStage.Count == 0) result.TypeStages = null;
            else result.TypeStages = project.ProjectStage.FirstOrDefault().IdStageNavigation.StagesTypeStages.FirstOrDefault().IdTypeStagesNavigation.TypeStages1;
            if (project.Metting.Count == 0) result.MettingDate = null;
            else result.MettingDate = project.Metting.FirstOrDefault().MettingDate;
            if (project.MilestonesProject.Count == 0) result.MillestoneDate = null;
            else
            {
                result.MillestoneDate = project.MilestonesProject.FirstOrDefault().IdMilestonesNavigation.DateMilestones;
                result.MillestoneType = project.MilestonesProject.FirstOrDefault().IdMilestonesNavigation.MilestonesTypeMilestones.FirstOrDefault().IdTypeMilestonesNavigation.TypeMilestones;
            }
            result.peoples = project.ProjectPeople.Select(p => p.IdPeopleNavigation.ToTeamsBstormShortDTO()).ToList();

            return result;
        }

        public static ClientShortDTO ToClientShortDTO(this People people)
        {
            if (people == null) return null;

            ClientShortDTO result = new ClientShortDTO
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                Society = people.IdSocietyNavigation.Name
            };

            return result;
        }

        public static TeamsBstormShortDTO ToTeamsBstormShortDTO(this People people)
        {
            if (people == null) return null;

            TeamsBstormShortDTO result = new TeamsBstormShortDTO
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
            };
            if (people.PeopleJob.Count == 0) result.LabelJob = null;
            else result.LabelJob = people.PeopleJob.FirstOrDefault().IdJobNavigation.Label;

            return result;
        } 

        public static ProjectPartialListDTO ToProjectPartialListDTO(this Project project)
        {
            if (project == null) return null;

            ProjectPartialListDTO result = new ProjectPartialListDTO
            {
                Project = project.Title,
                Description = project.Description,
                CreationDate = project.CreationDate,
                StartDate = project.StartDate,
                Society = project.IdSocietyNavigation.Name
            };

            return result;
        }

        public static ProjectDetailDTO ToProjectDetailDTO(this Project project)
        {
            if (project == null) return null;

            ProjectDetailDTO result = new ProjectDetailDTO
            {
                Titre = project.Title,
                Description = project.Description,
                Society = project.IdSocietyNavigation.Name,
                StartDate = project.StartDate,
                TypeStages = project.ProjectStage.FirstOrDefault().IdStageNavigation.StagesTypeStages.FirstOrDefault().IdTypeStagesNavigation.TypeStages1,
                TypeFollows = project.Follow.Select(x => x.FollowTypeFollow.Select(x => x.IdTypeFollowNavigation.ToTypeFollowForOneProjectDTO())),
                MillestoneDate = project.MilestonesProject.Select(x => x.IdMilestonesNavigation.DateMilestones).ToList(),
                MilestonesTypes = project.MilestonesProject.Select(x => x.IdMilestonesNavigation.MilestonesTypeMilestones.Select(x => x.IdTypeMilestonesNavigation.TypeMilestones)).ToList()
            };
            return result;
        }

        public static TypeFollowForOneProjectDTO ToTypeFollowForOneProjectDTO(this TypeFollow typeFollow)
        {
            if (typeFollow == null) return null;

            TypeFollowForOneProjectDTO result = new TypeFollowForOneProjectDTO
            {
                Label = typeFollow.Label,
                DescriptionFollow = typeFollow.FollowTypeFollow.FirstOrDefault().IdFollowNavigation.CommentDev
            };

            return result;
        }

        public static SocietyShortDTO ToSocietyShortDTO(this Society society)
        {
            if (society == null) return null;

            SocietyShortDTO result = new SocietyShortDTO
            {
                Name = society.Name,
                Email = society.IdSocietyNavigation.Email,
                Phone = society.IdSocietyNavigation.Phone
            };

            if (society.People.Count == 0) result.ContactFirstName = null;
            else
            {
                result.ContactFirstName = society.People.FirstOrDefault().FirstName;
                result.ContactLastName = society.People.FirstOrDefault().LastName;
            }
            return result;
        }

        public static ClientDetailsDTO ToClientDetailsDTO(this People people)
        {
            if (people == null) return null;

            ClientDetailsDTO result = new ClientDetailsDTO
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                Email = people.IdPeopleNavigation.Email,
                AdressCity = people.IdPeopleNavigation.AdressCity,
                AdressStreet = people.IdPeopleNavigation.AdressStreet,
                AdressCountry = people.IdPeopleNavigation.AdressCountry,
                AdressPostalCode = people.IdPeopleNavigation.AdressPostalCode,
                Phone = people.IdPeopleNavigation.Phone,
                Job = people.PeopleJob.FirstOrDefault().IdJobNavigation.Label,
                Society = people.IdSocietyNavigation.Name
            };

            return result;
        }

        public static TypeFollowsDTO ToTypeFollowsDTO(this TypeFollow typeFollow)
        {
            if (typeFollow == null) return null;

            TypeFollowsDTO result = new TypeFollowsDTO
            {
                Label = typeFollow.Label
            };

            return result;
        }

        public static MettingListDTO ToMettingListDTO(this Metting metting)
        {
            if (metting == null) return null;

            MettingListDTO result = new MettingListDTO
            {
                MettingDate = metting.MettingDate,
                Project = metting.IdProjectNavigation.Title,
            };

            if (metting.MettingPeople.Count == 0) result.Peoples = null;
            else result.Peoples = metting.MettingPeople.Select(x => x.IdPeopleNavigation.ToPeoplesMettingDTO()).ToList();

            return result;
        }
        
        public static PeoplesMettingDTO ToPeoplesMettingDTO(this People people)
        {
            if (people == null) return null;

            PeoplesMettingDTO result = new PeoplesMettingDTO
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                Email = people.IdPeopleNavigation.Email,
                Phone = people.IdPeopleNavigation.Phone
            };
            return result;
        }

        public static MilestonesProjectListDTO ToMilestonesProjectListDTO(this Milestones milestones)
        {
            if (milestones == null) return null;

            MilestonesProjectListDTO result = new MilestonesProjectListDTO
            {
                Project = milestones.MilestonesProject.FirstOrDefault().IdProjectNavigation.Title,
                MillestonesDate = milestones.DateMilestones
            };

            result.MillestonesTypeDTOs = milestones.MilestonesProject.Select(x => x.IdMilestonesNavigation.MilestonesTypeMilestones.Select(x => x.IdTypeMilestonesNavigation.ToMilestonesTypeDTO()));
            return result;
        }

        public static MilestonesTypeDTO ToMilestonesTypeDTO(this MilestonesType milestonesType)
        {
            if (milestonesType == null) return null;

            MilestonesTypeDTO result = new MilestonesTypeDTO
            {
                MilestoneType = milestonesType.TypeMilestones
            };

            return result;
        }

        public static StageTypesDTO ToStageTypesDTO(this TypeStages typeStages)
        {
            if (typeStages == null) return null;

            StageTypesDTO result = new StageTypesDTO
            {
                Label = typeStages.TypeStages1
            };
            return result;
        }
    }
}