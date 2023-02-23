using System.Text.Json.Serialization;

namespace POS.Application.Commons.Base;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? Errors { get; set; }
}
