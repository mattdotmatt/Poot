using Poot.AzureStorage.Entities;
using Poot.AzureStorage.Storage;

namespace Poot.AzureStorage.Queries
{
    public class AllPootles : StorageQuery<Pootle>
    {
        public AllPootles(string territory, string facility)
        {
            Query =
                Query.Where(InclusiveRangeFilter(
                    key: "PartitionKey",
                    @from: territory + "-" + facility,
                    to: territory + "-" + facility + "."));
        }
    }
}