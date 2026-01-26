namespace AgendaAPI.Dto.AppointmentResponseDto
{
    public record AppointmentResponseDto(
    int AppointmentId,
    string Title,
    string Description,
    DateTime Date,
    int UserId
);

}

