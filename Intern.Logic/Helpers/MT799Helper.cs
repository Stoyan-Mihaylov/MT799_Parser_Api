using Intern.Common.DatabaseModels;

namespace Intern.Logic.Helpers
{
    public static class MT799Helper
    {
        public static SwiftFileModel<Guid>? ParseToMT799(string fileData)
        {

            var extractedData = fileData.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            extractedData.Remove("5:");

            if (extractedData == null || extractedData.Count == 0)
            {
                throw new ArgumentException("Given data not sufficient.");
            }

            return new SwiftFileModel<Guid>(extractedData);

        }
    }
}
