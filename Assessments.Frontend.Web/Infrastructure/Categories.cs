﻿using System;
using System.Linq;
using Assessments.Mapping.AlienSpecies;
using Assessments.Shared.Helpers;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Categories
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Categories = Enum.GetValues<AlienSpeciesAssessment2023Category>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName().ToLowerInvariant(),
                Description = x.DisplayName()
            }).ToArray();
    }
}