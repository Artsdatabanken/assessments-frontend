﻿namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public interface IFilter<T>
    {
        string IGetActiveFilters(string s, T obj);

        string IGetActiveSelection(T obj);

        int IGetActiveSelectionCount(T obj);

        string[] IGetActiveSelectionElement(T obj);
    }
}