namespace Poot.AzureStorage
{
    public class AllPootles : StorageQuery<Pootle>
    {
        public AllPootles(string territory, string facility)
        {
            Query =
                Query.Where(InclusiveRangeFilter(
                    key: "PartitionKey",
                    from: territory + "-" + facility,
                    to: territory + "-" + facility + "."));
        }
    }
}