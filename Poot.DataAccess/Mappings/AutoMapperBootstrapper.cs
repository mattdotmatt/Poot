using AutoMapper;

namespace Poot.DAL.Mappings
{
    /// <summary>
    /// Bootstraps the mappings required in the DAL
    /// </summary>
    public static class AutoMapperBootstrapper
    {
        /// <summary>
        /// Initialize all profiles required in the DAL
        /// </summary>
        public static void InitMappings()
        {
            Mapper.AddProfile<PootProfile>();
        }
    }
}