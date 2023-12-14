using AppConfigMicroservice.Common.Models.Utils;
using AppConfigMicroservice.Common.Specifications;
using AppConfigMicroservice.Features.Config.Models;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Features.Config.Specifications;

public class GetProductionTypeSpecification : Specification<ConfigEntity>
{
    private readonly int _applicationId;
    public GetProductionTypeSpecification(int applicationId)
    {
        _applicationId = applicationId;
    }
    public override Expression<Func<ConfigEntity, bool>> Expression()
    {
        return p => p.EnvType == Convert.ToInt32(EnvType.PRODUCTION) && p.ApplicationId == _applicationId;
    }
}
