using Intern.Common.DatabaseModels;

namespace intern.DataAccess.Data
{
    public static class DatabaseContext
    {
        public static List<SwiftFileModel<Guid>?>? SwiftData { get; set; } = new List<SwiftFileModel<Guid>?>();
    }
}
