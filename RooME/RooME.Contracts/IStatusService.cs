namespace RooME.Contracts;
public interface IStatusService
{
    Task ShowStatus(StatusMessage message);
}
