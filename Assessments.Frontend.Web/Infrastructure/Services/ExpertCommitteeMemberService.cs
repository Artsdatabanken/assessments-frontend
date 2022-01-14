using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Shared.Helpers;
using CsvHelper.Configuration.Attributes;

namespace Assessments.Frontend.Web.Infrastructure.Services
{
    public class ExpertCommitteeMemberService
    {
        private readonly DataRepository _dataRepository;

        public ExpertCommitteeMemberService(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<ExpertCommitteeMember>> GetExpertCommitteeMembers(string expertCommitteeName, int year)
        {
            var data = await _dataRepository.GetData<ExpertCommitteeMember>(DataFilenames.SpeciesExpertCommitteeMembers);

            var expertCommitteeMembers = data.Where(x => x.ExpertCommittee.Equals(expertCommitteeName.Trim(), StringComparison.InvariantCultureIgnoreCase) && x.Year == year).ToList();
            
            if (!expertCommitteeMembers.Any()) // find members in composite commiteenames (comma separated)
            {
                expertCommitteeMembers = data.Where(x => x.Year == year && x.ExpertCommittee.Split(",", StringSplitOptions.TrimEntries)
                .Select(y => y.ToLowerInvariant()).Contains(expertCommitteeName.Trim().ToLowerInvariant()))
                    // remove duplicate names
                    .GroupBy(x => x.Name).Select(x => x.First()).ToList();
            }

            var results = expertCommitteeMembers.Select(x =>
            {
                x.ExpertCommittee = x.ExpertCommittee // remove assessmentarea from names in order to match mapped model
                    .Replace("(Svalbard)", string.Empty, StringComparison.InvariantCultureIgnoreCase)
                    .Replace("(Norge)", string.Empty, StringComparison.InvariantCultureIgnoreCase).Trim();
                return x;
            }).ToList();

            return results;
        }

        public async Task<string> GetExpertCommitteeName(string expertCommitteeName, int year)
        {
            var data = await _dataRepository.GetData<ExpertCommitteeMember>(DataFilenames.SpeciesExpertCommitteeMembers);

            var name = data.FirstOrDefault(x => x.ExpertCommittee.Equals(expertCommitteeName.Trim(), StringComparison.InvariantCultureIgnoreCase) && x.Year == year)?.ExpertCommittee;
	
            if (string.IsNullOrEmpty(name))
            {
                name =  data.FirstOrDefault(x => x.Year == year && x.ExpertCommittee.Split(",", StringSplitOptions.TrimEntries).Select(y => y.ToLowerInvariant()).Contains(expertCommitteeName.Trim().ToLowerInvariant()))
                    ?.ExpertCommittee;
            }
	
            return string.IsNullOrEmpty(name) ? string.Empty : name.Split(",", StringSplitOptions.TrimEntries).JoinAnd(", ", " og ");
        }
    }

    public class ExpertCommitteeMember
    {
        [Name("RodlisteAr")]
        public int Year { get; set; }

        public string ExpertCommittee { get; set; }

        public string SpeciesGroup { get; set; }

        [Name("EkspertgruppeRolle")]
        public string Role { get; set; }

        [Name("FulltNavn")]
        public string Name { get; set; }

        [Name("Etternavn")]
        public string LastName { get; set; }

        [Name("FornavnInit")]
        public string FirstNameInitals { get; set; }

        [Name("Institusjon")]
        public string Institution { get; set; }
    }
}
