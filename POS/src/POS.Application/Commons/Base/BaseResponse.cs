using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace POS.Application.Commons.Base;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public IEnumerable<ValidationFailure>? Errors { get; set; }
}
