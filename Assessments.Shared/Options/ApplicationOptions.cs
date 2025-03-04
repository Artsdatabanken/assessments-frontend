﻿namespace Assessments.Shared.Options;

public class ApplicationOptions // configured in appsettings.json
{
    public AlienSpecies2023Options AlienSpecies2023 { get; set; }

    public Species2021Options Species2021 { get; set; }

    public string SimpleApiKey { get; set; }
}

public class AlienSpecies2023Options
{
    public bool Enabled { get; set; }

    public bool IsHearing { get; set; }

    public bool TransformAssessments { get; set; }
}

public class Species2021Options
{
    public bool TransformAssessments { get; set; }
}