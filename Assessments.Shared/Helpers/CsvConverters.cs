using CsvHelper.TypeConversion;
using CsvHelper;
using CsvHelper.Configuration;

namespace Assessments.Shared.Helpers
{
    public class StringToNullableIntConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) => int.TryParse(text, out var integer) ? integer : null;
    }
}
