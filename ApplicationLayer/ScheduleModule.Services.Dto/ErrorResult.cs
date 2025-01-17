namespace ScheduleModule.Services.Dto;

public class ErrorResult
{
    public bool HasError { get; set; }

    public string? ErrorMessage { get; set; }

    public void AddError(string errorMessage)
    {
        HasError = true;
        ErrorMessage = errorMessage;
    }
}