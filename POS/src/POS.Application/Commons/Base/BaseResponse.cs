using POS.Application.DTO.Response;

namespace POS.Application.Commons.Base;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public IEnumerable<ErrorsResponseDto>? Errors { get; set; }
}
