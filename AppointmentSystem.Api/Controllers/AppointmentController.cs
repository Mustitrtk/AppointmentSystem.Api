using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(string id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Appointment appointment)
    {
        // Gelen appointment nesnesinin Id alanı boş olmalı
        appointment.Id = null;
        await _appointmentService.CreateAppointmentAsync(appointment);

        // Oluşturulan kaynağın adresiyle birlikte 201 Created döndürelim
        return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Appointment appointment)
    {
        var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (existingAppointment == null)
        {
            return NotFound();
        }

        appointment.Id = existingAppointment.Id; // ID'nin değişmediğinden emin ol
        var success = await _appointmentService.UpdateAppointmentAsync(id, appointment);

        return success ? NoContent() : BadRequest("Update failed.");
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (existingAppointment == null)
        {
            return NotFound();
        }

        var success = await _appointmentService.DeleteAppointmentAsync(id);

        return success ? NoContent() : BadRequest("Delete failed.");
    }
}