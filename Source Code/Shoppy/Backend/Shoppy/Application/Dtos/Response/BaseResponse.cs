using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Dtos.Response;

public abstract class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
}