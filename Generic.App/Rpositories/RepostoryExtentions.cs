using Generic.App.Entities;

namespace Generic.App.Rpositories
{
    public static class RepositoryExtentions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repo, IEnumerable<T> items)
            where T : IEntity
        {

            foreach (var item in items)
            {
                repo.Add(item);
            }
        }
    }
}
