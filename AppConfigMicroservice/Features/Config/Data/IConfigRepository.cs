using AppConfigMicroservice.Common.Repository;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Data;

public interface IConfigRepository : IRepositoryBase<ConfigEntity>;
