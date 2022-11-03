﻿using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public static class QueryHelpers
    {
        public static IQueryable<AlienSpeciesAssessment2023> ApplyParameters(AlienSpeciesListParameters parameters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(x => x.ScientificName.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));

            if (parameters.Area.Any())
                query = query.Where(x => parameters.Area.ToEnumerable<AlienSpeciesAssessment2023EvaluationContext>().Contains(x.EvaluationContext) && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien); // remove "regionallyalien" assessments when filtering by evaluation context

            if (parameters.Category.Any())
                query = query.Where(x => parameters.Category.ToEnumerable<AlienSpeciesAssessment2023Category>().Contains(x.Category));

            if (parameters.EstablishmentCategories.Any())
                query = ApplyEstablishmentCategories(parameters.EstablishmentCategories, query);

            if (parameters.ProductionSpecies.Any())
                query = query.Where(x => parameters.ProductionSpecies.Contains(x.ProductionSpecies.ToString()));

            if (parameters.SpeciesGroups.Any())
                query = query.Where(x => parameters.SpeciesGroups.Any(y => AlienSpeciesHelpers.GetSpeciesGroupByShortName(y) == x.SpeciesGroup));

            if (string.IsNullOrEmpty(parameters.SortBy) || parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.ScientificName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.ScientificName);
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.VernacularName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.VernacularName);
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.Category), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.Category);

            return query;
        }

        public static AlienSpeciesListParameters UpdateParameters(AlienSpeciesListParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.RemoveFilters))
            {
                parameters = new AlienSpeciesListParameters(parameters.IsCheck, parameters.Meta, parameters.Name);
            }

            return parameters;
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyEstablishmentCategories(string[] establishmentCategories, IQueryable<AlienSpeciesAssessment2023> query)
        {
            const string doorKnockerShort = "eda";
            const string doorKnocker = "DoorKnocker";
            const string effect = "EffectWithoutReproduction";
            
            return query.Where(x => establishmentCategories.Contains(x.EstablishmentCategory) ||
                                    (establishmentCategories.Contains(doorKnockerShort) && (x.AlienSpeciesCategory == doorKnocker || x.AlienSpeciesCategory == effect)));
        }
    }
}